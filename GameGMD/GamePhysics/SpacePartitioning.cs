using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.CollisionsClasses
{
    public class SpacePartitioning
    {
        private readonly int xPart = 2;
        private readonly int yPart = 3;
        private readonly List<Collider>[,] colliders;
        private readonly float partWidth;
        private readonly float partHeight;

        public SpacePartitioning(int width, int height)
        {
            partWidth = (float)1300 / xPart;
            partHeight = (float)900 / yPart;

            colliders = new List<Collider>[xPart, yPart];

            for (int i = 0; i < yPart; i++)
            {
                for (int j = 0; j < xPart; j++)
                {
                    colliders[j, i] = new List<Collider>();
                }
            }
        }

        public IEnumerable<List<Collider>> GetCells()
        {
            for (int j = 0; j < yPart; j++)
            {
                for (int i = 0; i < xPart; i++)
                {
                    yield return colliders[i, j];
                }
            }
        }

        public void AddCollider(Collider collider)
        {
            int minX = Math.Max(0, (int)Math.Floor(collider.minBoundX / partWidth));
            int maxX = Math.Min(xPart - 1, (int)Math.Floor(collider.maxBoundX / partWidth));
            int minY = Math.Max(0, (int)Math.Floor(collider.minBoundY / partHeight));
            int maxY = Math.Min(yPart - 1, (int)Math.Floor(collider.maxBoundY / partHeight));

            for (int i = minX; i <= maxX; i++)
            {
                for (int j = minY; j <= maxY; j++)
                {
                    colliders[i, j].Add(collider);
                }
            }
        }

        public void RemoveCollider(Collider collider)
        {
            for (int i = 0; i < xPart; i++)
            {
                for (int j = 0; j < yPart; j++)
                {
                    colliders[i, j].Remove(collider);
                }
            }
        }

        public void UpdatePartition()
        {
            foreach (Collider collider in
                colliders
                .OfType<List<Collider>>()
                .SelectMany(c => c)
                .Distinct()
                .ToList())
            {

                  collider.UpdateCollider();

            }
        }

        public void UpdateCollider(Collider collider)
        {
            int minX = Math.Max(0, (int)Math.Floor(collider.minBoundX / partWidth));
            int maxX = Math.Min(xPart - 1, (int)Math.Floor(collider.maxBoundX / partWidth));
            int minY = Math.Max(0, (int)Math.Floor(collider.minBoundY / partHeight));
            int maxY = Math.Min(yPart - 1, (int)Math.Floor(collider.maxBoundY / partHeight));

            int j = 0;
            for (; j < minY; j++)
            {
                for (int i = 0; i < xPart; i++)
                {
                    colliders[i, j].Remove(collider);
                }
            }

            for (; j <= maxY; j++)
            {
                int i = 0;
                for (; i < minX; i++)
                {
                    colliders[i, j].Remove(collider);
                }

                for (; i <= maxX; i++)
                {
                    if (!colliders[i, j].Contains(collider))
                    {
                        colliders[i, j].Add(collider);
                    }
                }

                for (; i < xPart; i++)
                {
                    colliders[i, j].Remove(collider);
                }
            }

            for (; j < yPart; j++)
            {
                for (int i = 0; i < xPart; i++)
                {
                    colliders[i, j].Remove(collider);
                }
            }
        }
    }
}
