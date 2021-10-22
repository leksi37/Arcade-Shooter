using GameGMD.Flyweight;

namespace GameGMD.CollisionsClasses
{
    public class Collider
    {
        public GameObject gameObject;
        public float minBoundX;
        public float maxBoundX;
        public float minBoundY;
        public float maxBoundY;

        public Collider(GameObject gameObject)
        {
            this.gameObject = gameObject;
            UpdateCollider();
            CollisionDetector.spacePartitioning.AddCollider(this);
        }

        public void UpdateCollider()
        {
            minBoundX = gameObject.GetPositionX();
            maxBoundX = gameObject.GetPositionX() + gameObject.GetSizeX();
            minBoundY = gameObject.GetPositionY();
            maxBoundY = gameObject.GetPositionY() - 0.5f + gameObject.GetSizeY();
        }

        public void Collided(GameObject other)
        {
            if(!(gameObject is Player) && !(other is Player) && !(gameObject is IEnemy && other is IEnemy))
            {
                gameObject.CollisionTriggered(other);
                RemoveCollider();
            }
        }

        public void RemoveCollider()
        {
            CollisionDetector.spacePartitioning.RemoveCollider(this);
        }
    }
}
