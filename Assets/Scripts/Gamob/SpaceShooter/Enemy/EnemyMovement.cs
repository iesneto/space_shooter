using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);

            if(transform.position.y < -5f)
            {
                float randomX = Random.Range(-8f, 8f);
                transform.position = new Vector3(randomX, 7f, 0f);
            }
        }
    }
}

