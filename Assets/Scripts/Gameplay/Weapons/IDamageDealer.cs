
namespace Gameplay.Weapons
{
    // Interface for all damage dealing entities
    public interface IDamageDealer
    {
        
        UnitBattleIdentity BattleIdentity { get; } //used to distinguish enemies from allies

        float Damage { get; } //damage it deals

    }
}
