using GameGMD.EnemyPool;
using GameGMD.Flyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.Enemies
{
    class EnemySpawner
    {
        private EnemyPooling enemyFactory;

        public EnemySpawner()
        {
            enemyFactory = new EnemyPooling();
        }

        public void Remove(IEnemy enemy)
        {
            enemyFactory.AddEnemy(enemy);
        }

            public IEnemy Spawn()
        {
            int enemyId = Randomizer.Instance.GetRandomNumberBetween(1, 5);
            IEnemy enemy;
            switch (enemyId)
            {
                case 1:
                    enemy = enemyFactory.GetEnemy("octopus");
                    break;
                case 2:
                    enemy = enemyFactory.GetEnemy("pinkie");
                    break;
                case 3:
                    enemy = enemyFactory.GetEnemy("bubble");
                    break;
                case 4:
                    enemy = enemyFactory.GetEnemy("dragon");
                    break;
                default:
                    enemy = enemyFactory.GetEnemy("octopus");
                    break;
            }
            enemy.UpdatePosition(Randomizer.Instance.GetRandomNumberBetween(0, 600), -10);
            return enemy;
        }
    }
}
