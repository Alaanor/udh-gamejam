using Game.Artillery;
using UnityEngine;

namespace Game
{
	public class SpaceshipController : MonoBehaviour
	{
		public float Speed = 15f;
		public Gun GunSystem;

		private Rigidbody2D _rigidbody;

		private void Start()
		{
			GunSystem = GetComponent<Gun>();
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate ()
		{
			_rigidbody.MovePosition(transform.position + (Vector3) Game.Input.RawMovement * Time.deltaTime * Speed);
			GunSystem.Enabled = Game.Input.IsShooting;
		}
	}
}
