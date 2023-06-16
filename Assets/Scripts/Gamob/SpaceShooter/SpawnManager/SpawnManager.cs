using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Spawn
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private GameObject _tripleShotPrefab;
        [SerializeField] private float _enemyFrequency;
        [SerializeField] private Transform _enemyContainer;
        private bool _stopSpawning = false;


        public void StopSpawning()
        {
            _stopSpawning = true;
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
            StartCoroutine(SpawnTripleShot());
        }

        private IEnumerator SpawnEnemy()
        {
            while (!_stopSpawning)
            {
                Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
                GameObject enemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);
                enemy.transform.parent = _enemyContainer;
                yield return new WaitForSeconds(_enemyFrequency);
            }
        }

        private IEnumerator SpawnTripleShot()
        {
            while (!_stopSpawning)
            {
                Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
                Instantiate(_tripleShotPrefab, positionToSpawn, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(7, 11));
            }
        }
            
    }
}

