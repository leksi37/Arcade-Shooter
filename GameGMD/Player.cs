using GameGMD.CollisionsClasses;
using GameGMD.Flyweight;
using System.Drawing;

namespace GameGMD
{
    class Player: GameObject
    {
        private Bitmap SpriteImg;
        private Position position;
        
        public int Velocity { get; set; }

        public Player()
        {
            position = new Position();
            SpriteImg = Properties.Resources.player1;
            position.SetSize(SpriteImg.Width, SpriteImg.Height);
        }

        public void MoveRight(float distance)
        {
            position.MoveRightBy(distance);
        }

        public void MoveLeft(float distance)
        {
            position.MoveLeftBy(distance);
        }

        public void UpdatePosition(float X, float Y)
        {
            position.UpdatePosition(X, Y);
        }

        public Point GetLocation()
        {
            return position.GetXY();
        }

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(SpriteImg, position.GetLocationAndSize());
        }

        public float GetPositionX()
        {
            return GetLocation().X + 0f;
        }

        public float GetPositionY()
        {
            return GetLocation().Y + 0f;
        }

        public float GetSizeX()
        {
            return SpriteImg.Width;
        }

        public float GetSizeY()
        {
            return SpriteImg.Height;
        }

        public void CollisionTriggered(GameObject other)
        {
            if(other.GetType() is IEnemy)
            {
                //GAME OVER
            }
        }
    }
}
