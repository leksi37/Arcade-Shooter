using System;
using System.Drawing;

namespace GameGMD
{
    class EnemyData : PhysicsObject
    {
        public bool isDirty;

        public EnemyData(Bitmap SpriteImg)
        {
            physics = new Physics();
            physics.SetSize(SpriteImg.Width, SpriteImg.Height);
           
        }

        public void MoveDown(float distance)
        {
            physics.MoveDownBy(distance);
        }

        public void UpdatePosition(double X, double Y)
        {
            physics.UpdatePosition(X, Y);
        }

        public bool ShouldEndGame()
        {
            return physics.HitBottom();
        }

        public bool ShouldDestroy()
        {
            return isDirty;
        }

        public void Draw(Graphics graphics, Bitmap SpriteImg)
        {
            graphics.DrawImage(SpriteImg, physics.GetLocationAndSize());
        }

        public PhysicsObject GetObjectsPhysics()
        {
            return this;
        }

        public void DestroyEnemy()
        {
            isDirty = true;
        }
    }
}
