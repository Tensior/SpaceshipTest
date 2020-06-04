using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    // Movement system with gameplay area restriction
    public class RestrictedMovementSystem : MovementSystem
    {
        [SerializeField]
        private SpriteRenderer _representation; //reference to the moving object sprite

        protected override void Move( float amount, Vector3 axis )
        {
            // Only move if new position is in gemeply area (including bounds)
            var newPosition = transform.position + transform.TransformVector( amount * axis.normalized );
            if ( !GameAreaHelper.IsInGameplayArea( newPosition, _representation.bounds, true ) )
            {
                return;
            }
            transform.position = newPosition;
        }
    }
}
