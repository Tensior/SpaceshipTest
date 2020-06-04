using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable, IArmed
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField]
        private float _maxHealth;

        private float _currentHealth;


        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        public float MaxHealth => _maxHealth;

        public float CurrentHealth => _currentHealth;

        public static UnityAction<Transform> OnEnemySpaceshipFullyDamaged;
        public static UnityAction OnPlayerSpaceshipFullyDamaged;

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
            _currentHealth = _maxHealth;
            if ( _battleIdentity == UnitBattleIdentity.Ally )
            {
                GameController.Instance.UpdatePlayerHealth( _currentHealth, _maxHealth );
            }
        }
        
        public void ModifyHealth( float amount )
        {
            _currentHealth = Mathf.Min( _maxHealth, _currentHealth + amount );
            if ( _battleIdentity == UnitBattleIdentity.Ally )
            {
                GameController.Instance.UpdatePlayerHealth( _currentHealth, _maxHealth );
            }
            if ( _currentHealth <= 0f )
            {
                FullyDamaged();
            }
        }

        public void FullyDamaged()
        {
            if ( _battleIdentity == UnitBattleIdentity.Enemy )
            {
                OnEnemySpaceshipFullyDamaged?.Invoke( this.transform );
            }
            if ( _battleIdentity == UnitBattleIdentity.Ally )
            {
                OnPlayerSpaceshipFullyDamaged?.Invoke();
            }
            Destroy( gameObject );
        }

        public void MultiplyFireRate(float multiplier)
        {
            _weaponSystem.MultiplyFireRate( multiplier );
        }

        public void RestoreOriginalFireRate()
        {
            _weaponSystem.RestoreOriginalFireRate();
        }
    }
}
