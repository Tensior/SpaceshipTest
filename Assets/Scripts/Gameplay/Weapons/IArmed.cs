
namespace Gameplay.Weapons
{
    // Interface for all entities which can fire
    public interface IArmed
    {
        UnitBattleIdentity BattleIdentity { get; } //used to distinguish enemies from allies

        void MultiplyFireRate( float multiplier );

        void RestoreOriginalFireRate();
    }
}
