using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Flyweight
{
    interface ISparkle
    {
        void Sparkle(Graphics graphics);

        void ChangePosition(Point position);
        void ChangeSize();
    }
}
