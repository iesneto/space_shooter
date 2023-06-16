using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Player
{
    public class PlayerShooting : MonoBehaviour
    {

        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private GameObject _tripleShotPrefab;
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private float _laserRate = 0.2f;
        [SerializeField] private float _canShoot = -1f;
        [SerializeField] private bool _isTripleShotActive = false;

        // Update is called once per frame
        void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canShoot)
            {
                CoolDownLaser();

                if (_isTripleShotActive)
                {
                    Instantiate(_tripleShotPrefab, _shootPosition.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_laserPrefab, _shootPosition.position, Quaternion.identity);
                }

            }
        }

        private void CoolDownLaser()
        {
            _canShoot = Time.time + _laserRate;
        }
    }
}


