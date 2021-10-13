using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Flyweight
{
    class SparkleFactory
    {
        private static Dictionary<int, ISparkle> sparkles = new Dictionary<int, ISparkle>();
        public static ISparkle GetSparkleObject(int sparkleId)
        {
            if (sparkles.ContainsKey(sparkleId))
            {
                sparkles[sparkleId].ChangePosition(new Point(Randomizer.Instance.GetRandomNumberBetween(200,600), Randomizer.Instance.GetRandomNumberBetween(-10,470)));
                return sparkles[sparkleId];
            }
               
            else
            {
                ISparkle sparkle = null;
               
                if(sparkleId == 1)
                {
                    sparkle = new YellowSparkle();
                    sparkles.Add(sparkleId, sparkle);
                }
                else if(sparkleId == 2)
                {
                    sparkle = new BlueSparkle();
                    sparkles.Add(sparkleId, sparkle);
                }
                else if (sparkleId == 3)
                {
                    sparkle = new WhiteSparkle();
                    sparkles.Add(sparkleId, sparkle);
                }

                return sparkle;
            }
        }
    }
}
