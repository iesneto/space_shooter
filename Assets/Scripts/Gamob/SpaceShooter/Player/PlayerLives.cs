using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Player
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField] private int _lives;

        public void Damage()
        {
            _lives--;

            CheckLives();
        }

        private void CheckLives()
        {
            if (_lives > 0)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}

