

namespace Gameplay.Weapons
{
    public interface IDamagable
    {
    
        UnitBattleIdentity BattleIdentity { get; }

        float MaxHealth { get; }

        float CurrentHealth { get; }

        void ModifyHealth( float amount );

        void FullyDamaged();

    }


    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}


