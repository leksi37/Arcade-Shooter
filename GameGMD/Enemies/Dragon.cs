using System.Drawing;

namespace GameGMD.Flyweight
{
    class Dragon: IEnemy, GameObject
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

        public void UpdatePosition(float X, float Y )
        {
            Enemy.UpdatePosition(X, Y);
        }

        public bool ShouldDestroy()
        {
            return Enemy.ShouldDestroy();
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
            Enemy.shouldDestroy = false;
        }

        public void Render(Graphics graphics)
        {
            Enemy.MoveDown(distance);
            Enemy.Draw(graphics, SpriteImage);
        }

        public float GetPositionX()
        {
            return Enemy.GetX();
        }

        public float GetPositionY()
        {
            return Enemy.GetY();
        }
        public float GetSizeX()
        {
            return SpriteImage.Width;
        }

        public float GetSizeY()
        {
            return SpriteImage.Height;
        }

        public void CollisionTriggered(GameObject other)
        {
            Enemy.shouldDestroy = true;
        }
    }
}