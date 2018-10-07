using UnityEngine;

namespace Game
{
    public class Rotator : MonoBehaviour
    {
        public Vector2 RangeSpeed = new Vector2(0, 50);

        private void Update()
        {
            var speed = Random.Range(RangeSpeed.x, RangeSpeed.y);
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + speed * Time.deltaTime);
        }
    }
}