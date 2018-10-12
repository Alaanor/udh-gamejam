using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(TMP_Text))]
    public class LifeUiManager : MonoBehaviour
    {
        public Image RedScreen;
        
        private TMP_Text _text;
        private Image _image;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _image = GetComponentInChildren<Image>();
            Game.PlayerSpaceShip.OnTakeHit += LostALife;
        }

        private void LostALife()
        {
            new TweenChain()
                .append(Go.to(_image.transform, 0.3f, new TweenConfig().scale(2.5f).setEaseType(EaseType.ElasticIn)))
                .append(Go.to(_image.transform, 0.3f, new TweenConfig().scale(1f).setEaseType(EaseType.CubicIn)))
                .play();

            new TweenChain()
                .append(Go.to(RedScreen, 0.01f, new TweenConfig().colorProp("color", new Color(
                    RedScreen.color.r,
                    RedScreen.color.g,
                    RedScreen.color.b,
                    150f/255f
                )).setEaseType(EaseType.Linear)))
                .append(Go.to(RedScreen, 0.8f, new TweenConfig().colorProp("color", new Color(
                    RedScreen.color.r,
                    RedScreen.color.g,
                    RedScreen.color.b,
                    0f
                )).setEaseType(EaseType.ExpoIn)))
                .play();
        }

        private void Update()
        {
            _text.text = $"{Game.PlayerSpaceShip.Life}";
        }
    }
}