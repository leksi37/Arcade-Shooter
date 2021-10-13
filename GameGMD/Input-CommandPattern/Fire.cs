using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Input_CommandPattern
{
    class Fire: Command
    {
		public override void Execute(Object actor, Object obj)
		{
			((Bullet)actor).SpawnBullet((Point)obj);
		}
	}
}
