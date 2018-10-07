using Game.Pool;
using UnityEngine;

namespace Game.Artillery
{
    public abstract class Gun : MonoBehaviour
    {
        public bool Enabled = true;
        public float Cadence = 0.05f;
        public float Speed = 25f;
        public SpaceShip GunUser;
        public PoolManagerBullet BulletStock;

        private float _lastShootTime;
        
        private void Update()
        {
            var canShoot = Time.time > _lastShootTime;

            if (!Enabled || !canShoot)
                return;
            
            Shoot();
            _lastShootTime = Time.time + Cadence;
        }

        protected void ShootOne(Vector2 direction)
        {
            var bullet = BulletStock.GetItem();
            
            bullet.Pool = BulletStock;
            bullet.Direction = direction;
            bullet.Speed = Speed;
            bullet.gameObject.tag = GunUser.IsPlayer
                ? Game.FromPlayer
                : Game.FromEnemies;
            
            bullet.transform.position = GunUser.GetBulletStartPosition(bullet.Direction);
            bullet.transform.rotation = Quaternion.AngleAxis(
                Vector2.SignedAngle(Vector2.up, direction),
                Vector3.forward
            );
        }
        
        protected abstract void Shoot();
    }
}