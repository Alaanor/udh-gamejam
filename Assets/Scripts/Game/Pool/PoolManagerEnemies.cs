using Game.Artillery;
using UnityEngine;

namespace Game.Pool
{
    public class PoolManagerEnemies : PoolManager
    {
        public new SpaceShip GetItem()
        {
            var spaceShip = base.GetItem().GetComponent<SpaceShip>();
            var gunSystem = spaceShip.GetComponent<Gun>();
            gunSystem.BulletStock = Game.ShootPool;

            return spaceShip;
        }

        public new void GiveBackItem(GameObject obj)
        {
            obj.GetComponent<SpaceShip>().OnReset();
            base.GiveBackItem(obj);
        }
    }
}