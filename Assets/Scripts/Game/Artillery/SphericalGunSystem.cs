using System;
using UnityEngine;

namespace Game.Artillery
{
    public class SphericalGunSystem : Gun
    {
        public int AmountDirection = 5;
        public float Offset;
        
        protected override void Shoot()
        {
            for (var i = 0; i < AmountDirection; i++)
            {
                var radian = 2 * Math.PI / AmountDirection * i - Math.PI;
                radian += Offset + Mathf.Deg2Rad * GunUser.transform.rotation.eulerAngles.z;
                
                var direction = new Vector2(
                    (float) Math.Cos(radian),
                    (float) Math.Sin(radian)
                );
                
                ShootOne(direction);
            }
        }
    }
}