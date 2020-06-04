using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    // Base class for all projectiles
    public class Projectile : MonoBehaviour, IDamageDealer
    {

        [SerializeField]
        private float _speed; //speed of the projectile

        [SerializeField] 
        private float _damage; //damage the projectile deals on impact


        private UnitBattleIdentity _battleIdentity; //battle identity to know who can be damaged by this projectile


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
                && damagableObject.BattleIdentity != BattleIdentity) //can damage any object with different battle id
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
