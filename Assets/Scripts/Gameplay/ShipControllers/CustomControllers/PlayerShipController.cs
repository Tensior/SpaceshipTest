using Gameplay.ShipSystems;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private ControlType controlType;

        private KeyCode _fire;
        private string _movement;

        private void Awake()
        {
            switch(controlType)
            {
                case ControlType.Keyboard:
                    _fire = KeyCode.Space;
                    _movement = "HorizontalArrows";
                    break;
                case ControlType.Mouse:
                    _fire = KeyCode.Mouse0;
                    _movement = "HorizontalMouse";
                    break;
            }
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement( Input.GetAxis( _movement ) * Time.deltaTime );
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey( _fire ) )
            {
                fireSystem.TriggerFire();
            }
        }
    }

    public enum ControlType
    {
        Keyboard,
        Mouse
    }
}
