using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamob.SpaceShooter.Player;

namespace Gamob.SpaceShooter.Powerup
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _powerUpID;

        void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.down);

            if(transform.position.y < -4.5f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameObject player = other.gameObject;
                switch (_powerUpID)
                {
                    case 0:
                        ActivateTripleShot(player);
                        break;
                    case 1:
                        ActivateSpeedBoost(player);
                        break;
                    case 2:
                        ActivateShield(player);
                        break;
                    default:
                        break;
                }
                Destroy(gameObject);
            }
        }

        private void ActivateTripleShot(GameObject other)
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
            if (playerShooting == null)
            {
                return;
            }
            playerShooting.ActivateTripleShot();
        }

        private void ActivateSpeedBoost(GameObject other)
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement == null)
            {
                return;
            }
            playerMovement.ActivateSpeedBoost();
        }

        private void ActivateShield(GameObject other)
        {
            PlayerLives playerLives = other.GetComponent<PlayerLives>();
            if (playerLives == null)
            {
                return;
            }
            playerLives.ActivateShield();
        }
    }
}

