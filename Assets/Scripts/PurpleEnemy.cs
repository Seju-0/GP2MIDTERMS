using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : MonoBehaviour
{
    private Transform playerTransform;
    public float moveSpeed;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 moveDirection = playerTransform.position - transform.position;

            // Ensure the enemy only moves in the horizontal plane 
            moveDirection.y = 0;

            // Normalize the direction vector to get a unit vector
            moveDirection.Normalize();

            // Move the enemy towards the player's position
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PurpleBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            // Destroy the bullet if it hits something other than an enemy
            Destroy(other.gameObject);
        }
    }
}
