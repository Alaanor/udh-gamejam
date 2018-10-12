using UnityEngine;
using UnityEngine.SceneManagement;
using UnityScript.Steps;

namespace Game
{
    public class PressAnyKeyToReplay : MonoBehaviour
    {
        private float _sceneStartTime;
        
        private void Start()
        {
            _sceneStartTime = Time.time;
            Go.to(transform, 1f, new TweenConfig()
                .scale(1.15f)
                .setEaseType(EaseType.CubicInOut)
                .setIterations(int.MaxValue, LoopType.PingPong));
        }
        
        private void Update()
        {
            if (_sceneStartTime + 1f < Time.time && Input.anyKeyDown)
                SceneManager.LoadScene(Game.SceneGame);
        }
    }
}