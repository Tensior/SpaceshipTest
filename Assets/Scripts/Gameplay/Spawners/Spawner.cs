using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Spawners
{
    //Spawns game objects
    public class Spawner : MonoBehaviour
    {

        [SerializeField]
        private GameObject _object; //prefab of the object to be spawned
        
        [SerializeField]
        private Transform _parent; //parents transform, under which new objects will be created
        
        [SerializeField]
        private Vector2 _spawnPeriodRange; //min and max time gap between 2 spawn
        
        [SerializeField]
        private Vector2 _spawnDelayRange; //min and max delay before first spawn

        [SerializeField]
        private bool _autoStart = true; //flag to control automatic start of spawning


        private void Start()
        {
            if ( _autoStart )
            {
                StartSpawn();
            }
        }


        // Starts object spawning
        public void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        //Stops object spawing
        public void StopSpawn()
        {
            StopAllCoroutines();
        }


        // Coroutine for object spawning with randomized initial delay and time between spawns
        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
            
            while (true)
            {
                Instantiate(_object, transform.position, transform.rotation, _parent);
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
