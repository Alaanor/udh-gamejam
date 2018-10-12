using System.Collections;
using Game.Artillery;
using UnityEngine;

namespace Game
{
    public class SpaceShipEnemies : SpaceShip
    {
        public float Speed = 5f;
        public ParticleSystem OnDieParticle;
        private Rigidbody2D _rigidBody;
        private Gun _gun;
        private bool _isManageDyingEventRunning;
        private bool _throwAway;

        public SpaceShipEnemies()
        {
            IsPlayer = false;
        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _gun = GetComponent<Gun>();
        }

        private void Update()
        {
            if (!IsAlive)
                return;
            
            _rigidBody.MovePosition(_rigidBody.position + Vector2.down * Speed * Time.deltaTime);
            
            if (_throwAway && !_isManageDyingEventRunning)
                TrowAway();
        }

        protected override void OnDie()
        {
            base.OnDie();
            StartCoroutine(ManageDyingEvent());
            Game.ScoreManager.Score += 22500;
        }

        private IEnumerator ManageDyingEvent()
        {
            _isManageDyingEventRunning = true;
            OnDieParticle.gameObject.SetActive(true);
            OnDieParticle.Play();
            gameObject.transform.scaleTo(0.25f, 0f);
            _gun.Enabled = false;

            while (OnDieParticle.IsAlive())
                yield return null;

            _isManageDyingEventRunning = false;
        }

        public override void OnReset()
        {
            base.OnReset();
            _gun.Enabled = true;
            _throwAway = false;
            _isManageDyingEventRunning = false;
            OnDieParticle.gameObject.SetActive(false);
            gameObject.transform.localScale = Vector3.one;
        }

        public void TrowAway()
        {
            if (!_isManageDyingEventRunning)
                Game.EnemiesPool.GiveBackItem(gameObject);
            else
                _throwAway = true;
        }
        
        private void OnBecameInvisible()
        {
            if (gameObject.activeInHierarchy)
                OnDie();
        }

    }
}