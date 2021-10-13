using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD
{
    abstract class PhysicsObject
    {
        protected Physics physics { get; set; }
        public Rectangle GetBounds()
        {
            return physics.GetBounds();
        }
    }
}
