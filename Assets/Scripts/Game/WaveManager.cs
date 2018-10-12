using System.Collections;
using UnityEngine;

namespace Game
{
    public class WaveManager : MonoBehaviour
    {
        public WaveGenerator Generator;
        public WaveAnnouncer WaveAnnouncer;

        private int _currentLevel;
        
        private void Start()
        {
            StartCoroutine(NewWave());
        }

        private void NextLevel()
        {
            StartCoroutine(NewWave());
        }

        private IEnumerator NewWave()
        {
            yield return new WaitForSeconds(1f);
            WaveAnnouncer.ShowWave(++_currentLevel);
            yield return new WaitForSeconds(3.5f);
            Generator.StartWave(_currentLevel, NextLevel);
        }
    }
}