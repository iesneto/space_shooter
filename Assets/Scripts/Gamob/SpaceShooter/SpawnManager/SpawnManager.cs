using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Spawn
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _enemyFrequency;
        [SerializeField] private Transform _enemyContainer;
        private bool _stopSpawning = false;


        public void StopSpawning()
        {
            _stopSpawning = true;
        }

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            while (!_stopSpawning)
            {
                Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
                GameObject enemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);
                enemy.transform.parent = _enemyContainer;
                yield return new WaitForSeconds(_enemyFrequency);
            }
        }
    }
}

