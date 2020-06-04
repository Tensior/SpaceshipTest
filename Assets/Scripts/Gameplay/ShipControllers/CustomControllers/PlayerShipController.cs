using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    // Implements movement and fire control for player spaceship
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private ControlType controlType; //allows to choose between keyboard and mouse control schemas

        private KeyCode _fire; //keycode for fire button
        private string _horizontalMovement; //axis name for horizontal movement

        private void Awake()
        {
            switch(controlType)
            {
                case ControlType.Keyboard:
                    _fire = KeyCode.Space;
                    _horizontalMovement = "HorizontalArrows";
                    break;
                case ControlType.Mouse:
                    _fire = KeyCode.Mouse0;
                    _horizontalMovement = "HorizontalMouse";
                    break;
            }
        }

        // Passes player input to movement system
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement( Input.GetAxis( _horizontalMovement ) * Time.deltaTime );
        }

        // Passes player input to weapon system
        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey( _fire ) )
            {
                fireSystem.TriggerFire();
            }
        }
    }

    // enum for 2 control schemas
    public enum ControlType
    {
        Keyboard,
        Mouse
    }
}
