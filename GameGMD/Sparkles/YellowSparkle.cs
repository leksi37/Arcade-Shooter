using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Flyweight
{
    class YellowSparkle: ISparkle
    {
        private Bitmap SpriteImage = Properties.Resources.yellow;
        private Point position;
        private int smallerWith = 0;

        public void ChangePosition(Point position)
        {
            this.position = position;
        }

        public void ChangeSize()
        {
            smallerWith = Randomizer.Instance.GetRandomNumberBetween(1, 30);
        }

        public void Sparkle(Graphics graphics)
        {
            graphics.DrawImage(SpriteImage, new RectangleF(position.X, position.Y, (SpriteImage.Width-20) - smallerWith, (SpriteImage.Height-20) - smallerWith));
        }
    }
}
