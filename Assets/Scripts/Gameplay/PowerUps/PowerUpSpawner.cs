using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Spaceships;

namespace Gameplay.PowerUps
{
    public class PowerUpSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _powerUps; //prefabs

        [SerializeField, Range(0f, 1f)]
        private float _spawnProbability = 1f;

        private void Awake()
        {
            Spaceship.OnEnemySpaceshipFullyDamaged += SpawnRandomPowerUp;
        }

        private void OnDisable()
        {
            Spaceship.OnEnemySpaceshipFullyDamaged -= SpawnRandomPowerUp;
        }

        private void SpawnRandomPowerUp( Transform transform )
        {
            bool shouldSpawn = Random.Range( 0f, 1f ) <= _spawnProbability;
            if ( shouldSpawn )
            {
                var randomPowerUp = _powerUps[Random.Range( 0, _powerUps.Length )];
                Instantiate( randomPowerUp, transform.position, transform.rotation );
            }
        }
    }
}
