using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD
{
    public sealed class Randomizer
    {
        private static Randomizer instance = null;
        private static readonly object padlock = new object();
        private Random random;

        Randomizer()
        {
            random = new Random();
        }

        public int GetRandomNumberBetween(int min, int max)
        {
            return random.Next(min, max);
        }

        public static Randomizer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Randomizer();
                    }
                    return instance;
                }
            }
        }
    }
}
