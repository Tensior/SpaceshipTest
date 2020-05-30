using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {

        [SerializeField]
        private float _lateralMovementSpeed;
        
        [SerializeField]
        private float _longitudinalMovementSpeed;

        [SerializeField]
        private bool _restrictByGameArea = false;
    

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }

        
        private void Move(float amount, Vector3 axis)
        {
            var newPosition = transform.position + transform.TransformVector( amount * axis.normalized );
            if ( _restrictByGameArea && !GameAreaHelper.IsInGameplayArea( newPosition ) )
            {
                return;
            }
            //transform.Translate( amount * axis.normalized );
            transform.position = newPosition;
        }
    }
}
