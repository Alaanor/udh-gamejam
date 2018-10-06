using UnityEngine;

namespace Game.Artillery
{
    public class LinearGunSystem : Gun
    {
        public Vector2 Direction = Vector2.up;

        protected override void Shoot()
        {
            ShootOne(Direction);
        }
    }
}