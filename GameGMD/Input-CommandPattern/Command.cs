using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD
{
    public abstract class Command
    {
        public abstract void Execute(Object actor, Object obj);
    }
}
