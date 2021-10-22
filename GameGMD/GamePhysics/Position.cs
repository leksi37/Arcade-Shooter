using System.Drawing;

namespace GameGMD.CollisionsClasses
{
    public class Position
    {
        private float X { get; set; }
        private float Y { get; set; }
        private float Width { get; set; }
        private float Height { get; set; }


        public RectangleF GetLocationAndSize()
        {
            return new RectangleF(X, Y, Width, Height);
        }

        public Point GetXY()
        {
            return new Point((int)X, (int)Y);
        }

        public void UpdatePosition(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void UpdatePosition(Point points)
        {
            X = points.X + 30;
            Y = points.Y - 15;
        }

        public void SetSize(float Width, float Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public void MoveLeftBy(float distance)
        {
            if (X >= 5)
                X -= distance;
        }
        public void MoveRightBy(float distance)
        {
            if (X <= 655)
                X += distance;
        }

        public void MoveDownBy(float distance)
        {
            Y += distance;
        }
        public void MoveUpBy(float distance)
        {
            Y -= distance;
        }
        public bool HitBottom()
        {
            if (Y >= 450)
                return true;
            else
                return false;
        }

        public bool HitTop()
        {
            if (Y <= -10)
                return true;
            else 
                return false;
        }
    }
}
