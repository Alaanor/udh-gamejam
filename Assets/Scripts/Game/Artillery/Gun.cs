using Game.Pool;
using UnityEngine;

namespace Game.Artillery
{
    public abstract class Gun : MonoBehaviour
    {
        public float Cadence = 0.05f;
        public PoolManagerBullet BulletStock;

        private float _lastShootTime;
        
        private void Update()
        {
            var canShoot = Time.time > _lastShootTime;

            if (!Game.Input.IsShooting || !canShoot)
                return;
            
            Shoot();
            _lastShootTime = Time.time + Cadence;
        }

        protected abstract void Shoot();
    }
}