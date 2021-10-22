using GameGMD.CollisionsClasses;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameGMD
{
    class Bullet: GameObject
    {
        private readonly Bitmap SpriteImg = Properties.Resources.Fire;
        public bool toBeDestroyed = false;
        private Position position;

        public Bullet()
        {
            position = new Position();
            position.SetSize(10, 10);
            
        }

        public void SpawnBullet(Point playerXY)
        {
            position.UpdatePosition(playerXY);
        }

        private void Move()
        {
            position.MoveUpBy(1);
        }

        public bool shouldDestroy()
        {
            if (toBeDestroyed || position.HitTop())
                return true;
            else
                return false;
        }

        public void Render(Graphics graphics)
        {
            Move();
            graphics.DrawImage(SpriteImg, position.GetLocationAndSize());
        }

        public float GetPositionX()
        {
            return position.GetXY().X;
        }

        public float GetPositionY()
        {
            return position.GetXY().Y;
        }

        public float GetSizeX()
        {
            return 10;// SpriteImg.Width;
        }

        public float GetSizeY()
        {
            return 10;// SpriteImg.Height;
        }

        public void CollisionTriggered(GameObject other)
        {
            toBeDestroyed = true;
        }
    }
}
