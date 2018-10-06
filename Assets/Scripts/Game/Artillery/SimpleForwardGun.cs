using UnityEngine;

namespace Game.Artillery
{
    public class SimpleForwardGun : Gun
    {
        protected override void Shoot()
        {
            var bullet = Game.ShootPool.GetItem();
            bullet.Direction = Vector2.up;
            bullet.Speed = 25f;
            bullet.gameObject.transform.position = Game.PlayerSpaceShip
                .GetBulletStartPosition(bullet.Direction);
        }
    }
}