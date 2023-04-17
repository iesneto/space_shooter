using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamob.SpaceShooter.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 3.5f;

        // Start is called before the first frame update
        void Start()
        {
            transform.position = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            CheckBounds();
        }

        private void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

            transform.Translate(direction * _speed * Time.deltaTime);
        }

        private void CheckBounds()
        {
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 3.8f, 0f), 0);

            if (transform.position.x >= 11.7f)
            {
                transform.position = new Vector3(-11.7f, transform.position.y, 0);
            }
            else if (transform.position.x <= -11.7)
            {
                transform.position = new Vector3(11.7f, transform.position.y, 0);
            }

        }
    }
}

