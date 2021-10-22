using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Flyweight
{
    interface IEnemy
    {

        void SetFallRate(float distance);

        void UpdatePosition(float X, float Y);

        bool ShouldDestroy();

        void DestroyEnemy();

        bool ShouldEndGame();
        void Reset();
    }
}