﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Flyweight
{
    class Pinkie: IEnemy, GraphicsObject
    {
        private EnemyData Enemy;
        private Bitmap SpriteImage;
        public string name { get; }
        private float distance;

        public Pinkie()
        {
            name = "pinkie";
            SpriteImage = Properties.Resources.monsterP;
            Enemy = new EnemyData(SpriteImage);
        }

        public void SetFallRate(float distance)
        {
            this.distance = distance;
        }

        public void UpdatePosition(float X, float Y)
        {
            Enemy.UpdatePosition(X+0.01f, Y);
        }

        public bool ShouldDestroy()
        {
            return Enemy.ShouldDestroy();
        }

        public PhysicsObject GetObjectsPhysics()
        {
            return Enemy.GetObjectsPhysics();
        }

        public void DestroyEnemy()
        {
            Enemy.DestroyEnemy();
        }
        public bool ShouldEndGame()
        {
            return Enemy.ShouldEndGame();
        }

        public void Reset()
        {
            Enemy.isDirty = false;
        }

        public void Render(Graphics graphics)
        {
            Enemy.MoveDown(distance);
            Enemy.Draw(graphics, SpriteImage);
        }
    }
}
