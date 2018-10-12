using TMPro;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreManager : MonoBehaviour
    {
        public const string LatestScore = "latestScore";
        public const string BestScore = "bestScore";
        
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

        public static float GetBestScore()
            => PlayerPrefs.GetFloat(BestScore, 0f);

        public static float GetLatestScore()
            => PlayerPrefs.GetFloat(LatestScore, 0f);

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            Score = 0;
        }

        private void Update()
        {
            Score += 15;
        }

        public void SaveScore()
        {
            if (GetBestScore() < _score)
                PlayerPrefs.SetFloat(BestScore, _score);
            PlayerPrefs.SetFloat(LatestScore, _score);
            PlayerPrefs.Save();
            
            Debug.Log($"Best: {GetBestScore()} Latest: {GetLatestScore()}");
        }
    }
}