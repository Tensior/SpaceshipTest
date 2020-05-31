using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class RestrictedMovementSystem : MovementSystem
    {
        [SerializeField]
        private SpriteRenderer _representation;

        protected override void Move( float amount, Vector3 axis )
        {
            var newPosition = transform.position + transform.TransformVector( amount * axis.normalized );
            if ( !GameAreaHelper.IsInGameplayArea( newPosition, _representation.bounds, true ) )
            {
                return;
            }
            transform.position = newPosition;
        }
    }
}
