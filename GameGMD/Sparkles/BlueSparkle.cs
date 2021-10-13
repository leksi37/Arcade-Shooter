using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Flyweight
{
    class BlueSparkle: ISparkle
    {
        private Bitmap SpriteImage = Properties.Resources.blue;
        private Point position;
        private int smallerWith = 0;
        public void ChangePosition(Point position)
        {
            this.position = position;
        }

        public void ChangeSize()
        {
            smallerWith = Randomizer.Instance.GetRandomNumberBetween(1,30);
        }

        public void Sparkle(Graphics graphics)
        {
            graphics.DrawImage(SpriteImage, new RectangleF(position.X, position.Y, SpriteImage.Width - smallerWith + 30, SpriteImage.Height - smallerWith + 30));
        }
    }
}
