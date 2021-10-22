using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD
{
    public interface GameObject
    {
        void Render(Graphics graphics);

        float GetPositionX();
        float GetPositionY();
        float GetSizeX();
        float GetSizeY();

        void CollisionTriggered(GameObject other);
    }
}
