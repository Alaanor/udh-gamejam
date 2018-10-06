using UnityEngine;

namespace Game
{
    public class WaveManager : MonoBehaviour
    {
        public int CurrentLevel = 1;
        public WaveGenerator Generator;

        private void Start()
        {
            Generator.StartWave(CurrentLevel);
        }
    }
}