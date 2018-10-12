using UnityEngine;

namespace Game
{
    public static class Vector2Extensions
    {
        public static Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max)
        {
            return new Vector2(
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y)
            );
        }

        // ReSharper disable once InconsistentNaming
        public static Vector3 ClampXY(this Vector3 value, Vector2 min, Vector2 max)
        {
            return new Vector3(
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y),
                value.z
            );
        }
    }
}