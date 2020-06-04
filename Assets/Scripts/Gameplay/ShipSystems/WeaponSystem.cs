using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    // Holds all weapons of the spaceship and all actions with them must be passes through this system
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Weapon> _weapons; //all weapons of this spaceship

        //currently applied fire rate multiplier, cached so that we don't multiply it several times, but choose the biggest one
        private float _activeFireRateMultiplier = 1f;
        public float ActiveFireRateMultiplier => _activeFireRateMultiplier;

        // Initiates underlying weapons with given battle identity
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }

        // Triggers fire on underlying weapons
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        // Multiplies fire rate for underlying weapons
        public void MultiplyFireRate( float multiplier )
        {
            if ( multiplier > _activeFireRateMultiplier )
            {
                _weapons.ForEach( w => w.MultiplyFireRate( multiplier ) );
                _activeFireRateMultiplier = multiplier;
            }
        }

        // Restores fire rate for underlying weapons
        public void RestoreOriginalFireRate()
        {
            _weapons.ForEach( w => w.RestoreOriginalFireRate() );
            _activeFireRateMultiplier = 1f;
        }
    }
}
