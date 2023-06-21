using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamob.SpaceShooter.Spawn;

namespace Gamob.SpaceShooter.Player
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField] private int _lives;
        [SerializeField] private GameObject _shieldEffect;
        private SpawnManager _spawnManager;
        private bool _isShieldActive;

        public void ActivateShield()
        {
            _isShieldActive = true;
            _shieldEffect.SetActive(true);
        }

        public void Damage()
        {
            if (_isShieldActive)
            {
                ShieldPowerDown();
                return;
            }

            _lives--;

            CheckLives();
        }

        private void Start()
        {
            _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            _shieldEffect.SetActive(false);
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

        private void ShieldPowerDown()
        {
            _isShieldActive = false;
            _shieldEffect.SetActive(false);
        }
    }
}

