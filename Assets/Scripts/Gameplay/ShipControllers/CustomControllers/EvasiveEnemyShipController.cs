using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EvasiveEnemyShipController : EnemyShipController
{
    [SerializeField]
    private Vector2 _directionChangeDelay;

    private int _evasionDirection = 1; //must be 1 or -1

    private void Start()
    {
        StartCoroutine( LateralDirectionChangeEvasion() );
    }

    protected override void ProcessHandling( MovementSystem movementSystem )
    {
        movementSystem.LongitudinalMovement( Time.deltaTime );
        movementSystem.LateralMovement( Time.deltaTime * _evasionDirection );
    }


    private IEnumerator LateralDirectionChangeEvasion()
    {
        while ( true )
        {
            yield return new WaitForSeconds( Random.Range( _directionChangeDelay.x, _directionChangeDelay.y ) );
            _evasionDirection = -_evasionDirection;
        }
    }
}
