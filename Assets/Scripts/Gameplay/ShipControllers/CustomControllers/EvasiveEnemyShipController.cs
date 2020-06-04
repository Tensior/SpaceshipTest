using System.Collections;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    // Extends enemy controller with horizontal movement
    public class EvasiveEnemyShipController : EnemyShipController
    {
        [SerializeField]
        private Vector2 _directionChangeDelay; //min and max delay between direction change (left/right)

        private int _evasionDirection = 1; //must be 1 or -1, corresponds to left/right

        private void Start()
        {
            StartCoroutine( LateralDirectionChangeEvasion() );
        }

        // Both longitudinal and lateral movements
        protected override void ProcessHandling( MovementSystem movementSystem )
        {
            movementSystem.LongitudinalMovement( Time.deltaTime );
            movementSystem.LateralMovement( Time.deltaTime * _evasionDirection );
        }


        // Changes horizontal direction to the opposite after random delays
        private IEnumerator LateralDirectionChangeEvasion()
        {
            while ( true )
            {
                yield return new WaitForSeconds( Random.Range( _directionChangeDelay.x, _directionChangeDelay.y ) );
                _evasionDirection = -_evasionDirection;
            }
        }
    }
}