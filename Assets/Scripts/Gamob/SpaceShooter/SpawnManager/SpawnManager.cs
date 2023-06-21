using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Spawn
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private List<GameObject> _powerUps;
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
            StartCoroutine(SpawnPowerup());
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

        private IEnumerator SpawnPowerup()
        {
            while (!_stopSpawning)
            {
                Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
                int randomPowerUp = Random.Range(0, _powerUps.Count);
                Instantiate(_powerUps[randomPowerUp], positionToSpawn, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(7, 11));
            }
        }
            
    }
}

