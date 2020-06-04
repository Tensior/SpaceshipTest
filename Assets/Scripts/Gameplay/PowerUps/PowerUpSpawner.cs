using UnityEngine;
using Gameplay.Spaceships;

namespace Gameplay.PowerUps
{
    // Spawns powerups randomly when an enemy spaceship is destroyed
    public class PowerUpSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _powerUps; //prefabs of possible powerups

        [SerializeField, Range(0f, 1f)]
        private float _spawnProbability = 1f; //probability of spawning a powerup on enemy death

        private void OnEnable()
        {
            //subscribe to static event
            Spaceship.OnEnemySpaceshipFullyDamaged += SpawnRandomPowerUp;
        }

        private void OnDisable()
        {
            //unsubscribe fron static event
            Spaceship.OnEnemySpaceshipFullyDamaged -= SpawnRandomPowerUp;
        }

        // Randomly chooses a powerup from provided prefabs and spawns it with provided posibility and given transform
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
