using Game.Artillery;
using UnityEngine;

namespace Game.Pool
{
    public class PoolManagerBullet : PoolManager
    {
        public new BulletController GetItem()
        {
            var obj = base.GetItem();
            var controller = obj.GetComponent<BulletController>()
                             ?? obj.AddComponent<BulletController>();
            return controller;
        }
    }
}