using Game.Artillery;
using UnityEngine;

namespace Game
{
    public abstract class SpaceShip : MonoBehaviour
    {
        public bool IsPlayer { get; protected set; }
        public int Life = 3;
        public float SpaceShipSize = 0.5f;

        private int _lifeSettings;

        private void Awake()
        {
            _lifeSettings = Life;
        }

        public Vector3 GetBulletStartPosition(Vector2 direction)
        {
            direction = direction.normalized;
            return transform.position + (Vector3)(SpaceShipSize * direction);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Game.FromEnemies) && IsPlayer ||
                other.CompareTag(Game.FromPlayer) && !IsPlayer)
                Life--;
            else
                return;
            
            if (Life == 0)
                OnDie();

            other.GetComponent<BulletController>().Die();
        }

        public void OnReset()
        {
            Life = _lifeSettings;
        }

        public virtual void OnDie() {}
    }
}