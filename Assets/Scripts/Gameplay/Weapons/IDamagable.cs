

namespace Gameplay.Weapons
{
    // Interface for all damagable entities
    public interface IDamagable
    {
    
        UnitBattleIdentity BattleIdentity { get; } //used to distinguish enemies from allies

        float MaxHealth { get; }

        float CurrentHealth { get; }

        void ModifyHealth( float amount ); //implementations must support both positive and negative amounts

        void FullyDamaged(); //what happens when current health is <= 0

    }


    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}


