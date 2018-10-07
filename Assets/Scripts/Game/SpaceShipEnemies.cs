using System.Collections;
using UnityEngine;

namespace Game
{
    public class SpaceShipEnemies : SpaceShip
    {
        public float Speed = 5f;
        public ParticleSystem OnDieParticle;
        private Rigidbody2D _rigidBody;

        public SpaceShipEnemies()
        {
            IsPlayer = false;
        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rigidBody.MovePosition(_rigidBody.position + Vector2.down * Speed * Time.deltaTime);
        }

        public override void OnDie()
        {
            StartCoroutine(ManageDyingEvent());
            Game.ScoreManager.Score += 200;
        }

        private IEnumerator ManageDyingEvent()
        {
            OnDieParticle.gameObject.SetActive(true);
            OnDieParticle.Play();
            gameObject.transform.scaleTo(0.25f, 0f);

            while (OnDieParticle.IsAlive())
                yield return null;
            
            gameObject.transform.localScale = Vector3.one;
            Game.EnemiesPool.GiveBackItem(gameObject);
        }
        
        private void OnBecameInvisible()
        {
            Game.EnemiesPool.GiveBackItem(gameObject);
        }

    }
}