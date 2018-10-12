using TMPro;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TMP_Text))]
    public class RemainingEnemiesTextManager : MonoBehaviour
    {
        public WaveManager WaveManager;
        
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = $"{WaveManager.Generator.AmountEnemiesRemaining}";
        }
    }
}