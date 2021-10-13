﻿using System.Drawing;

namespace GameGMD
{
    class Player: PhysicsObject, GraphicsObject
    {
        private Bitmap SpriteImg;
        
        public int Velocity { get; set; }

        public Player()
        {
            physics = new Physics();
            SpriteImg = Properties.Resources.player1;
            physics.SetSize(SpriteImg.Width, SpriteImg.Height);
        }

        public void MoveRight(int distance)
        {
            physics.MoveRightBy(distance);
        }

        public void MoveLeft(int distance)
        {
            physics.MoveLeftBy(distance);
        }

        public void UpdatePosition(double X, double Y)
        {
            physics.UpdatePosition(X, Y);
        }

        public Point GetLocation()
        {
            return physics.GetXY();
        }

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(SpriteImg, physics.GetLocationAndSize());
        }
    }
}