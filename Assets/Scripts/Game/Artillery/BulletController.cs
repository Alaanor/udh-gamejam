using Game.Pool;
using UnityEngine;

namespace Game.Artillery
{
    public class BulletController : MonoBehaviour
    {
        public Vector2 Direction = Vector2.zero;
        public float Speed;
        public PoolManagerBullet Pool;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(transform.position + (Vector3) Direction * Time.deltaTime * Speed);
        }

        private void OnBecameInvisible()
        {
            Pool.GiveBackItem(gameObject);
        }

        public void Die()
        {
            Pool.GiveBackItem(gameObject);
        }
    }
}