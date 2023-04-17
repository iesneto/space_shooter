using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Player
{
    public class PlayerShooting : MonoBehaviour
    {

        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private Transform _shootPosition;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_laserPrefab, _shootPosition.position, Quaternion.identity);
            }
        }
    }
}


