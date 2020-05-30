using Gameplay.ShipSystems;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }
    }
}
