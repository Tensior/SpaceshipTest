using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.PowerUps
{
    public class HealthPowerUp : MonoBehaviour
    {

        [SerializeField]
        private float _healthAmount;

        [SerializeField]
        private float _speed;

        // Update is called once per frame
        void Update()
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

        public void ApplyTo( IDamagable damagable )
        {
            damagable.ModifyHealth( _healthAmount );
            Destroy( gameObject );
        }
    }
}
