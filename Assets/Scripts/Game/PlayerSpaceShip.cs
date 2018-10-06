using UnityEngine;

namespace Game
{
    public class PlayerSpaceShip : MonoBehaviour
    {
        public float SpaceShipSize = 0.5f;
        
        public Vector3 GetBulletStartPosition(Vector2 direction)
        {
            direction = direction.normalized;
            return transform.position + (Vector3)(SpaceShipSize * direction);
        }
    }
}