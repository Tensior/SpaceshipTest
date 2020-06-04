using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.ShipControllers
{
    // Base class for movement and fire controls of a spaceship
    public abstract class ShipController : MonoBehaviour
    {

        protected ISpaceship _spaceship; //reference to the spaceship object it controls


        public void Init(ISpaceship spaceship)
        {
            _spaceship = spaceship;
        }


        private void Update()
        {
            ProcessHandling(_spaceship.MovementSystem);
            ProcessFire(_spaceship.WeaponSystem);
        }

        // Implements movement during one frame
        protected abstract void ProcessHandling(MovementSystem movementSystem);

        // Implements firing during one frame
        protected abstract void ProcessFire(WeaponSystem fireSystem);
    }
}
