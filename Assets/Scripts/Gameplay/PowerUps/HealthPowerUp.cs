using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.PowerUps
{
    // Powerup which increases current health
    public class HealthPowerUp : MonoBehaviour
    {

        [SerializeField]
        private float _healthAmount; //healed amount

        [SerializeField]
        private float _speed; //fall speed for the powerup game object

        private void Update()
        {
            transform.Translate( Vector3.up * Time.deltaTime * _speed );
        }

        private void OnCollisionEnter2D( Collision2D other )
        {
            var damagable = other.gameObject.GetComponent<IDamagable>();

            if ( damagable != null && damagable.BattleIdentity == UnitBattleIdentity.Ally ) //picked by player
            {
                ApplyTo( damagable );
            }
        }

        // Actual effect which powerup has on entity it was applied to
        public void ApplyTo( IDamagable damagable )
        {
            damagable.ModifyHealth( _healthAmount );
            Destroy( gameObject );
        }
    }
}
