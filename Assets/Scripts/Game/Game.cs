using Game.Pool;
using UnityEngine;

namespace Game
{
    //Singleton
    public class Game : MonoBehaviour
    {
        public static readonly PlayerInput Input = new PlayerInput();
        public static PoolManagerBullet ShootPoolLine;
        public static PoolManagerBullet ShootPoolTriangle;
        public static PoolManagerEnemies EnemiesPool;
        public static SpaceShip PlayerSpaceShip;
        public static ScoreManager ScoreManager;

        public const string FromPlayer = "from player";
        public const string FromEnemies = "from enemies";

        private void Start()
        {
            // I don't like this kind of access but well, it's a gamejam so fuck
            ShootPoolLine = GameObject.Find("ShootPoolLine").GetComponent<PoolManagerBullet>();
            ShootPoolTriangle = GameObject.Find("ShootPoolTriangle").GetComponent<PoolManagerBullet>();
            EnemiesPool = GameObject.Find("EnemiesPool").GetComponent<PoolManagerEnemies>();
            PlayerSpaceShip = GameObject.Find("Player").GetComponent<SpaceShip>();
            ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }

        private void Update()
        {
            Input.Update();
        }
    }
}