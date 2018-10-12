using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreDisplayer : MonoBehaviour
    {
        public TMP_Text BestScore;
        public TMP_Text LatestScore;

        private void Start()
        {
            BestScore.text = $"Best: {ScoreManager.GetBestScore()}";
            LatestScore.text = $"Score: {ScoreManager.GetLatestScore()}";
        }
    }
}