using System;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public class Projectile : MonoBehaviour, IDamageDealer
    {

        [SerializeField]
        private float _speed;

        [SerializeField] 
        private float _damage;


        private UnitBattleIdentity _battleIdentity;


        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Damage => _damage;

        

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        

        private void Update()
        {
            Move( _speed );
        }

        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ModifyHealth( -_damage );
            }
        }


        protected virtual void Move( float speed )
        {
            transform.Translate( speed * Time.deltaTime * Vector3.up );
        }
    }
}
