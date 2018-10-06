using UnityEngine;

namespace Game
{
    public class SpaceShip : MonoBehaviour
    {
        public bool IsPlayer;
        public int Life = 3;
        public float SpaceShipSize = 0.5f;
        
        public Vector3 GetBulletStartPosition(Vector2 direction)
        {
            direction = direction.normalized;
            return transform.position + (Vector3)(SpaceShipSize * direction);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Game.FromEnemies) && IsPlayer ||
                other.CompareTag(Game.FromPlayer) && !IsPlayer)
                Life--;
        }
    }
}