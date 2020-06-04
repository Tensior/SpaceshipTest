using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    // Implements movement and fire control for enemy spaceship
    public class EnemyShipController : ShipController
    {

        [SerializeField]
        private Vector2 _fireDelay; //min and max delay between firings

        private bool _fire = true; //flag to show if this enemy can fire

        // Simply moves enemy vertically
        protected override void ProcessHandling( MovementSystem movementSystem )
        {
            movementSystem.LongitudinalMovement( Time.deltaTime );
        }

        // Triggers fire (if it can) and randomly delays the next one
        protected override void ProcessFire( WeaponSystem fireSystem )
        {
            if ( !_fire )
                return;

            fireSystem.TriggerFire();
            StartCoroutine( FireDelay( Random.Range( _fireDelay.x, _fireDelay.y ) ) );
        }


        // Fire delay for entire weapon system (not a single weapon)
        private IEnumerator FireDelay( float delay )
        {
            _fire = false;
            yield return new WaitForSeconds( delay );
            _fire = true;
        }
    }
}