using Game.Artillery;
using UnityEngine;

namespace Game
{
	public class SpaceshipController : MonoBehaviour
	{
		public float Speed = 15f;
		public Gun GunSystem;

		private void Start()
		{
			GunSystem = GetComponent<Gun>();
		}

		private void Update ()
		{
			transform.position += (Vector3) Game.Input.RawMovement * Time.deltaTime * Speed;
			GunSystem.Enabled = Game.Input.IsShooting;
		}
	}
}
