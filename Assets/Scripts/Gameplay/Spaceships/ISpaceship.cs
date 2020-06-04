
using Gameplay.ShipSystems;

namespace Gameplay.Spaceships
{
    // Every spaceship must implement this interface
    public interface ISpaceship
    {

        MovementSystem MovementSystem { get; }
        WeaponSystem WeaponSystem { get; }

    }
}
