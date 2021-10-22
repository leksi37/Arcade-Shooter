using GameGMD.CollisionsClasses;
using System;
using System.Drawing;

namespace GameGMD
{
    class EnemyData
    {
        public bool shouldDestroy;
        private Position position;

        public EnemyData(Bitmap SpriteImg)
        {
            position = new Position();
            position.SetSize(SpriteImg.Width, SpriteImg.Height);
           
        }

        public void MoveDown(float distance)
        {
            position.MoveDownBy(distance);
        }

        public void UpdatePosition(float X, float Y)
        {
            position.UpdatePosition(X, Y);
        }

        public float GetY()
        {
            return position.GetXY().Y;
        }

        public float GetX()
        {
            return position.GetXY().X;
        }


        public bool ShouldEndGame()
        {
            return position.HitBottom();
        }

        public bool ShouldDestroy()
        {
            if (shouldDestroy)
            {
                  shouldDestroy = true;
            }
            return shouldDestroy;
        }

        public void Draw(Graphics graphics, Bitmap SpriteImg)
        {
            graphics.DrawImage(SpriteImg, position.GetLocationAndSize());
        }
        public void DestroyEnemy()
        {
            shouldDestroy = true;
        }
    }
}