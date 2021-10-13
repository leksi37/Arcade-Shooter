using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Input_CommandPattern
{
    public class MoveRight: Command
    {
        public override void Execute(Object actor, Object obj)
        {
            ((Player)actor).MoveRight((int)obj);
        }
    }
}
