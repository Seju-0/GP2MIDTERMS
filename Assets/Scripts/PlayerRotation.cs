using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float maxRotationAngle;
    public float maxRange;

    private Transform playerTransform;
    private GameObject nearestEnemy;

    private void Start()
    {
        playerTransform = transform;
    }

    private void Update()
    {
        FindNearestEnemy();

        if (nearestEnemy != null)
        {
            RotateTowardsNearestEnemy();
        }
    }

    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(playerTransform.position, enemy.transform.position);

            if (distance < nearestDistance && distance <= maxRange)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }
    }

    private void RotateTowardsNearestEnemy()
    {
        Vector3 targetDirection = nearestEnemy.transform.position - playerTransform.position;
        targetDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        float angle = Quaternion.Angle(playerTransform.rotation, targetRotation);

        // Check if the angle is within the allowed range
        if (angle <= maxRotationAngle)
        {
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
