using System.Drawing;

namespace GameGMD
{
    class Physics
    {
        private Rectangle Bounds;
        private float X { get; set; }
        private float Y { get; set; }
        private float Width { get; set; }
        private float Height { get; set; }

        public Physics()
        {
            Bounds = new Rectangle();
        }

        private void UpdateBounds()
        {
            Bounds.X = (int)X;
            Bounds.Y = (int)Y;
            Bounds.Width = (int)Width;
            Bounds.Height = (int)Height;
        }

        public bool IsHitBy(Rectangle otherObjBounds)
        {
            UpdateBounds();
            if (Bounds.IntersectsWith(otherObjBounds))
                return true;
            else
                return false;
        }

        public Rectangle GetBounds()
        {
            UpdateBounds();
            return Bounds;
        }

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

        public void MoveLeftBy(int distance)
        {
            if (X >= 5)
                X -= distance;
        }
        public void MoveRightBy(int distance)
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
