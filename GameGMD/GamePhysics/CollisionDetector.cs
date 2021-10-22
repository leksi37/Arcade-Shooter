using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.CollisionsClasses
{
    public class CollisionDetector
    {
        public static SpacePartitioning spacePartitioning { get; private set; }

        public CollisionDetector(int screenWidth, int screenHeight)
        {
            spacePartitioning = new SpacePartitioning(screenWidth, screenHeight);
        }

        public void DetectCollisions()
        {
            HashSet<HashSet<Collider>> collisions = new HashSet<HashSet<Collider>>();

            foreach (List<Collider> cell in spacePartitioning.GetCells())
            {
                 DetectCollisionsInCell(cell, collisions);
            }

            foreach (var collision in collisions)
            {
                var col = collision.ToList();
                Collider c1 = col[0];
                Collider c2 = col[1];

                c1.Collided(c2.gameObject); 
                c2.Collided(c1.gameObject);
            }
        }

        private void DetectCollisionsInCell(List<Collider> cell, HashSet<HashSet<Collider>> result)
        {
            for (int i = 0; i < cell.Count; i++)
            {
                for (int j = i + 1; j < cell.Count; j++)
                {
                    CheckCollision(result, cell[i], cell[j]);
                }
            }
        }

        private void CheckCollision(HashSet<HashSet<Collider>> result, Collider c1, Collider c2)
        {
            if (IsColliding(c1, c2))
            {
                var collision = new HashSet<Collider> { c1, c2 };
                result.Add(collision);
            }
        }

        private bool IsColliding(Collider c1, Collider c2)
        {
            if (c1.maxBoundX < c2.minBoundX || c2.maxBoundX < c1.minBoundX)
            {
                return false;
            }

            if (c1.maxBoundY < c2.minBoundY || c2.maxBoundY < c1.minBoundY)
            {
                return false;
            }

            return true;
        }

        public void Update()
        {
            spacePartitioning.UpdatePartition();
        }
    }
}
