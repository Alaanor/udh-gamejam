using UnityEngine;

namespace Game
{
    public class PlayerInput
    {
        public Vector2 RawMovement;
        public bool IsShooting;
        
        public void Update()
        {
            RawMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if (Input.GetKeyDown(KeyCode.Space))
                IsShooting = !IsShooting;
        }
    }
}