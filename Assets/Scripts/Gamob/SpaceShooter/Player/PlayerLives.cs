using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamob.SpaceShooter.Spawn;

namespace Gamob.SpaceShooter.Player
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField] private int _lives;
        private SpawnManager _spawnManager;

        public void Damage()
        {
            _lives--;

            CheckLives();
        }

        private void Start()
        {
            _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        }

        private void CheckLives()
        {
            if (_lives > 0)
            {
                return;
            }

            if(_spawnManager != null)
            {
                _spawnManager.StopSpawning();
            }
            
            Destroy(gameObject);
        }
    }
}

