using GameGMD.Flyweight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGMD.EnemyPool
{
    // This clas is a Factory method pattern and it's used for enemy object pooling
    // Used by the EnemySpawner(Creator) clas, which is used in the gameLoop(Product)
    class EnemyPooling
    {
        // The Enemy Objects Pool
        private readonly List<IEnemy> enemyPool;

        public EnemyPooling()
        {
            enemyPool = new List<IEnemy>();
        }

        public void AddEnemy(IEnemy enemy)
        {
            enemyPool.Add(enemy);
        }
        public IEnemy GetEnemy(string type)
        {
            IEnemy enemy;
            // Check from the collection pool. If exists, return
            // object; else, create new
            switch (type)
            {
                case "octopus":
                    {
                        enemy = GetOctopus();
                        break;
                    }
                case "pinkie":
                    {
                        enemy = GetPinkie();
                        break;
                    }
                case "bubble":
                    {
                        enemy = GetBubble();
                        break;
                    }
                case "dragon":
                    {
                            enemy = GetDragon();
                        break;
                    }
                default:
                    enemy = GetOctopus();
                    break;
            }
            return enemy;
        }

        protected IEnemy GetOctopus()
        {
            IEnemy octopus;
            if (enemyPool.Count > 0 
                &&
                enemyPool.Any(o => o.GetType() == typeof(Octopus)))
            {
                octopus = enemyPool.Find(enemy => enemy.GetType() == typeof(Octopus));
                enemyPool.Remove(octopus);
                if (octopus == null)
                    octopus = new Octopus();
            }
            else
            {
                octopus = new Octopus();
            }
            return octopus;
        }

        protected IEnemy GetPinkie()
        {
            IEnemy pinkie;
            // Check if there are any objects in the current Pool
            if (enemyPool.Count > 0
                &&
                enemyPool.Any(o => o.GetType() == typeof(Pinkie)))
            {
                pinkie = enemyPool.Find(enemy => enemy.GetType() == typeof(Pinkie));
                enemyPool.Remove(pinkie);
                if (pinkie == null)
                    pinkie = new Pinkie();
            }
            else
            {
                pinkie = new Pinkie();
            }
            return pinkie;
        }

        protected IEnemy GetBubble()
        {
            IEnemy bubble;
            if (enemyPool.Count > 0
                &&
                enemyPool.Any(o => o.GetType() == typeof(BlueBubble)))
            {
                bubble = enemyPool.Find(enemy => enemy.GetType() == typeof(BlueBubble));
                enemyPool.Remove(bubble);
                if (bubble == null)
                    bubble = new BlueBubble();
            }
            else
            {
                bubble = new BlueBubble();
            }
            return bubble;
        }

        protected IEnemy GetDragon()
        {
            IEnemy dragon;
            if (enemyPool.Count > 0
                &&
                enemyPool.Any(o => o.GetType() == typeof(Dragon)))
            {
                dragon = enemyPool.Find(enemy => enemy.GetType() == typeof(Dragon));
                enemyPool.Remove(dragon);
                if (dragon == null)
                    dragon = new Dragon();
            }
            else
            {
                dragon = new Dragon();
            }
            return dragon;
        }
    }
}
