using TMPro;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(TMP_Text))]
    public class WaveAnnouncer : MonoBehaviour
    {
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _text.transform.localScale = Vector3.zero;
        }

        public void ShowWave(int lvl)
        {
            _text.text = $"Wave {lvl}";

            var scaleInTween = Go.to(transform, 0.5f, new TweenConfig()
                .scale(1)
                .setEaseType(EaseType.ElasticOut)
            );

            var scaleOutTween = Go.to(transform, 0.5f, new TweenConfig()
                .scale(0)
                .setEaseType(EaseType.ElasticOut)
            );

            var chain = new TweenChain();
            chain
                .append(scaleInTween)
                .appendDelay(3f)
                .append(scaleOutTween);
            chain.play();
        }
    }
}