﻿using System;
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

        void UpdatePosition(double X, double Y);

        bool ShouldDestroy();

        PhysicsObject GetObjectsPhysics();

        void DestroyEnemy();

        bool ShouldEndGame();
        void Reset();
    }
}