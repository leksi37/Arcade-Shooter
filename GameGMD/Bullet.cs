using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameGMD
{
    class Bullet: PhysicsObject, GraphicsObject
    {
        private readonly Bitmap SpriteImg = Properties.Resources.Fire;
        public bool isDirty;

        public Bullet()
        {
            physics = new Physics();
            physics.SetSize(10, 10);
            
        }

        public void SpawnBullet(Point playerXY)
        {
            physics.UpdatePosition(playerXY);
        }

        public bool CollidesWith(PhysicsObject physicsObj)
        {
            return this.physics.IsHitBy(physicsObj.GetBounds());
        }

        private void Move()
        {
            physics.MoveUpBy(1);
        }

        public bool shouldDestroy()
        {
            return physics.HitTop();
        }

        public void Render(Graphics graphics)
        {
            Move();
            graphics.DrawImage(SpriteImg, physics.GetLocationAndSize());
        }
    }
}
