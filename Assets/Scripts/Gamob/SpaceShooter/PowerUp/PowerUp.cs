using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamob.SpaceShooter.Player;

namespace Gamob.SpaceShooter.Powerup
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private float _speed;        

        void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);

            if(transform.position.y < -4.5f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
                if (playerShooting != null)
                {
                    playerShooting.ActivateTripleShot();
                }
                Destroy(gameObject);
            }
        }
    }
}

