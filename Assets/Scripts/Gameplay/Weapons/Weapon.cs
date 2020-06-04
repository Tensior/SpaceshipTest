using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    // Describes firing weapon with reloading
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        private Projectile _projectile; //projectile prefab

        [SerializeField]
        private Transform _barrel; //position where projectile will be created on fire

        [SerializeField]
        private float _cooldown; //time between firing 2 projectiles

        private float _originalCooldown; //saved so that we can restore it later


        private bool _readyToFire = true; //flag to show if this weapon can fire
        private UnitBattleIdentity _battleIdentity; //used to distinguish enemies from allies



        //Initialize this weapon
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
            _originalCooldown = _cooldown;
        }
        
        
        // Fire new projectile if we can and start reloading
        public void TriggerFire()
        {
            if ( !_readyToFire )
            {
                return;
            }
            
            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            StartCoroutine(Reload(_cooldown));
        }

        //Multiplies fire rate
        public void MultiplyFireRate( float multiplier )
        {
            if ( multiplier != 0f )
            {
                _cooldown = _originalCooldown / multiplier;
            }
        }

        // Restores original fire rate (when its multiplication buff ends)
        public void RestoreOriginalFireRate()
        {
            _cooldown = _originalCooldown;
        }


        // Disables fire ability until cooldown is over
        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }

    }
}
