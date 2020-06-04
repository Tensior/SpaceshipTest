
namespace Gameplay.Weapons
{
    public interface IArmed
    {
        UnitBattleIdentity BattleIdentity { get; }

        void MultiplyFireRate( float multiplier );

        void RestoreOriginalFireRate();
    }
}
