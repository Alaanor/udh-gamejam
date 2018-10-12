using Game.Pool;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    //Singleton
    public class Game : MonoBehaviour
    {
        public static readonly PlayerInput Input = new PlayerInput();
        public static PoolManagerBullet ShootPoolLine;
        public static PoolManagerBullet ShootPoolTriangle;
        public static PoolManagerEnemies EnemiesPool;
        public static SpaceShipPlayer PlayerSpaceShip;
        public static ScoreManager ScoreManager;

        public const string FromPlayer = "from player";
        public const string FromEnemies = "from enemies";
        public static string SceneGame = "Scenes/Game";
        public static string SceneScore = "Scenes/Score";

        private void Start()
        {
            // I don't like this kind of access but well, it's a gamejam so fuck
            ShootPoolLine = GameObject.Find("ShootPoolLine").GetComponent<PoolManagerBullet>();
            ShootPoolTriangle = GameObject.Find("ShootPoolTriangle").GetComponent<PoolManagerBullet>();
            EnemiesPool = GameObject.Find("EnemiesPool").GetComponent<PoolManagerEnemies>();
            PlayerSpaceShip = GameObject.Find("Player").GetComponent<SpaceShipPlayer>();
            ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

            PlayerSpaceShip.OnDieEvent += EndGame;
        }

        private void Update()
        {
            Input.Update();
        }

        private void EndGame()
        {
            ScoreManager.SaveScore();
            SceneManager.LoadScene(SceneScore);
        }
    }
}