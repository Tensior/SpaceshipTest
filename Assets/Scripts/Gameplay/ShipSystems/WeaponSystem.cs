using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Weapon> _weapons;

        private float _activeFireRateMultiplier = 1f;
        public float ActiveFireRateMultiplier => _activeFireRateMultiplier;



        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }
        
        
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        public void MultiplyFireRate( float multiplier )
        {
            if ( multiplier > _activeFireRateMultiplier )
            {
                _weapons.ForEach( w => w.MultiplyFireRate( multiplier ) );
                _activeFireRateMultiplier = multiplier;
            }
        }

        public void RestoreOriginalFireRate()
        {
            _weapons.ForEach( w => w.RestoreOriginalFireRate() );
            _activeFireRateMultiplier = 1f;
        }
    }
}
