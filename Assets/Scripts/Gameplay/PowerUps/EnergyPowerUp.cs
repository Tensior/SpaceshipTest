using Gameplay.Weapons;
using System.Collections;
using UnityEngine;

namespace Gameplay.PowerUps
{

    public class EnergyPowerUp : MonoBehaviour
    {

        [SerializeField]
        private float _fireRateMultiplier;

        [SerializeField]
        private float _duration;

        [SerializeField]
        private float _speed;

        [SerializeField]
        private SpriteRenderer _representation;

        public float Duration => _duration;

        public static EnergyPowerUp ActiveEnergyPowerUp;

        private bool _isApplied = false;

        // Update is called once per frame
        private void Update()
        {
            if ( !_isApplied )
            {
                transform.Translate( Vector3.up * Time.deltaTime * _speed );
            }
        }

        private void OnCollisionEnter2D( Collision2D other )
        {
            var armed = other.gameObject.GetComponent<IArmed>();

            if ( armed != null && armed.BattleIdentity == UnitBattleIdentity.Ally ) //picked by player
            {
                ApplyTo( armed );
            }
        }

        public void ApplyTo( IArmed armed )
        {
            //check for already applied boost and disable it before applying current one
            //this logic may be changed if there are different types of energy powerups
            //with different fire rate multipliers and durations
            if ( ActiveEnergyPowerUp != null )
            {
                ActiveEnergyPowerUp.PowerUpExpired( armed );
            }

            ActiveEnergyPowerUp = this;

            armed.MultiplyFireRate( _fireRateMultiplier );
            StartCoroutine( PowerUpExpiring( armed ) );

            _isApplied = true;
            transform.localPosition = Vector3.zero;
            _representation.enabled = false;
        }

        public void PowerUpExpired( IArmed armed )
        {
            armed.RestoreOriginalFireRate();
            Destroy( gameObject );
        }

        private IEnumerator PowerUpExpiring( IArmed armed )
        {
            yield return new WaitForSeconds( _duration );
            PowerUpExpired( armed );
        }
    }
}