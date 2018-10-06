using UnityEngine;

namespace Game
{
	public class SpaceshipController : MonoBehaviour
	{
		public float Speed = 15f;
		
		private void Update ()
		{
			transform.position += (Vector3) Game.Input.RawMovement * Time.deltaTime * Speed;
		}
	}
}
