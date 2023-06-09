using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamob.SpaceShooter.Player;

namespace Gamob.SpaceShooter.Enemy
{
    public class EnemyCollisions : MonoBehaviour
    {
        [SerializeField] private string _laserTag;
        [SerializeField] private string _playerTag;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_playerTag))
            {
                PlayerLives lives = other.GetComponent<PlayerLives>();

                if(lives == null)
                {
                    return;
                }

                lives.Damage();
                Destroy(gameObject);
                return;
            }
            if (other.CompareTag(_laserTag))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                return;
            }
        }

    }
}
