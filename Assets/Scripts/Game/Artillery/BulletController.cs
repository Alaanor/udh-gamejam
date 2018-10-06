using UnityEngine;

namespace Game.Artillery
{
    public class BulletController : MonoBehaviour
    {
        public Vector2 Direction = Vector2.zero;
        public float Speed;
        
        private void Update()
        {
            transform.position += (Vector3) Direction * Time.deltaTime * Speed;
        }

        private void OnBecameInvisible()
        {
            Game.ShootPool.GiveBackItem(gameObject);
        }
    }
}