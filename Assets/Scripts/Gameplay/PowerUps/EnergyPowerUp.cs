using Gameplay.Weapons;
using System.Collections;
using UnityEngine;

namespace Gameplay.PowerUps
{
    // Powerup which temporarily increases fire rate
    public class EnergyPowerUp : MonoBehaviour
    {

        [SerializeField]
        private float _fireRateMultiplier; //multiplier for fire rate

        [SerializeField]
        private float _duration; //duration of the effect

        [SerializeField]
        private float _speed; //fall speed for the powerup game object

        [SerializeField]
        private SpriteRenderer _representation; //reference to the sprite to hide it on apply

        public float Duration => _duration;

        //need to save the current active power up of this type to disable it 
        //when another one is applied before the previous one expired
        public static EnergyPowerUp ActiveEnergyPowerUp;

        private bool _isApplied = false; //flag to know if this powerup was applied

        private void Update()
        {
            if ( !_isApplied )
            {
                Move();
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

        // Movement of the game object for one frame
        private void Move()
        {
            transform.Translate( Vector3.up * Time.deltaTime * _speed );
        }

        // Actual effect which powerup has on entity it was applied to
        public void ApplyTo( IArmed armed )
        {
            //check for already applied powerup and disable it before applying current one
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
            _representation.enabled = false; //hide this powerup
        }

        // Actions which happen when the powerup expires
        public void PowerUpExpired( IArmed armed )
        {
            armed.RestoreOriginalFireRate();
            Destroy( gameObject );
        }

        // Coroutine for delayed expiring
        private IEnumerator PowerUpExpiring( IArmed armed )
        {
            yield return new WaitForSeconds( _duration );
            PowerUpExpired( armed );
        }
    }
}