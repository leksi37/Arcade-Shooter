using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Flyweight
{
    class Dragon: IEnemy, GraphicsObject
    {
        private EnemyData Enemy;
        private Bitmap SpriteImage;
        public string name { get; }
        private float distance;

        public Dragon()
        {
            name = "dragon";
            SpriteImage = Properties.Resources.monsterF;
            Enemy = new EnemyData(SpriteImage);
        }

        public void SetFallRate(float distance)
        {
            this.distance = distance;
        }

        public void UpdatePosition(double X, double Y)
        {
            Enemy.UpdatePosition(X, Y);
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
