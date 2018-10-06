using Game.Pool;
using UnityEngine;

namespace Game
{
    //Singleton
    public class Game : MonoBehaviour
    {
        public static readonly PlayerInput Input = new PlayerInput();
        public static PoolManagerBullet ShootPool;
        public static PlayerSpaceShip PlayerSpaceShip;

        private void Start()
        {
            // I don't like this kind of access but well, it's a gamejam so fuck
            ShootPool = GameObject.Find("ShootPool").GetComponent<PoolManagerBullet>();
            PlayerSpaceShip = GameObject.Find("Player").GetComponent<PlayerSpaceShip>();
        }

        private void Update()
        {
            Input.Update();
        }
    }
}