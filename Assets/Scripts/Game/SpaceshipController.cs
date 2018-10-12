using Game.Artillery;
using UnityEngine;

namespace Game
{
	public class SpaceshipController : MonoBehaviour
	{
		public float Speed = 15f;
		public Gun GunSystem;

		private Rigidbody2D _rigidbody;
		private Camera _mainCamera;

		private void Start()
		{
			GunSystem = GetComponent<Gun>();
			_rigidbody = GetComponent<Rigidbody2D>();
			_mainCamera = Camera.main;
		}

		private void FixedUpdate ()
		{
			var rect = _mainCamera.OrthographicRect();
			var target = transform.position + (Vector3) Game.Input.RawMovement * Time.deltaTime * Speed;

			target = target.ClampXY(rect.min, rect.max);
			_rigidbody.MovePosition(target);
			
			GunSystem.Enabled = Game.Input.IsShooting;
		}
	}
}
