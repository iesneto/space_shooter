using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Weapons
{
    public class LaserMovement : MonoBehaviour
    {
        [SerializeField] private float _laserSpeed = 8.0f;

        void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.up * Time.deltaTime * _laserSpeed);
            CheckPositionToDestroy();
        }

        private void CheckPositionToDestroy()
        {
            if (transform.position.y <= 7f)
            {
                return;
            }

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }
}

