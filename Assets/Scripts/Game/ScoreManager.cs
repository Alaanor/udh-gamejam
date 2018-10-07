using TMPro;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreManager : MonoBehaviour
    {
        private float _score;
        private TMP_Text _text;
        
        public float Score
        {
            get { return _score; }
            set
            {
                _score = value;
                _text.text = $"{_score}";
            }
        }

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            Score = 0;
        }

        private void Update()
        {
            Score += 15;
        }

    }
}