using UnityEngine;

namespace Gameplay.ShipSystems
{
    // Controls lateral and longtitudal movements separately
    public class MovementSystem : MonoBehaviour
    {

        [SerializeField]
        private float _lateralMovementSpeed; //speed of the lateral movement

        [SerializeField]
        private float _longitudinalMovementSpeed; //speed of the longtitudal movement

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }

        
        // Moves game object by given value and in given direction
        protected virtual void Move(float amount, Vector3 axis)
        {
            transform.Translate( amount * axis.normalized );
        }
    }
}
