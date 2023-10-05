using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform spawnBulletHere;
    public GameObject[] bulletPrefabs;
    private int currentBulletIndex = 0;
    private float baseFireRate;
    public float bulletSpeed;
    public float fireRate;

    void Start()
    {
        baseFireRate = fireRate;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefabs[currentBulletIndex], spawnBulletHere.position, Quaternion.identity);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * bulletSpeed;
            currentBulletIndex = (currentBulletIndex + 1) % bulletPrefabs.Length;
        }
    }
}
