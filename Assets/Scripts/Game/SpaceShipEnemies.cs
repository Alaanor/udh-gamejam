using System.Collections;
using UnityEngine;

namespace Game
{
    public class SpaceShipEnemies : SpaceShip
    {
        public ParticleSystem OnDieParticle;

        public SpaceShipEnemies()
        {
            IsPlayer = false;
        }
        
        public override void OnDie()
        {
            StartCoroutine(ManageDyingEvent());
        }

        private IEnumerator ManageDyingEvent()
        {
            OnDieParticle.gameObject.SetActive(true);
            OnDieParticle.Play();
            gameObject.transform.scaleTo(0.25f, 0f);

            while (OnDieParticle.IsAlive())
                yield return null;
            
            Destroy(gameObject);
        }
    }
}