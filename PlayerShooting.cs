using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector
    public Transform bulletSpawnPoint; // Assign the spawn point of the bullet in the Inspector
    public float fireRate = 0.2f; // Time interval between each shot

    private float nextFireTime = 0f; // Tracks the time for the next shot
    private Vector2 joystickDirection; // Stores the joystick direction

    void Update()
    {
        // Get joystick input (assuming joystick axes are "Horizontal" and "Vertical")
        joystickDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Check if joystick is being moved
        if (joystickDirection.magnitude > 0.1f) // Threshold to ensure slight movements don't trigger shooting
        {
            if (Time.time >= nextFireTime)
            {
                ShootBullet();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void ShootBullet()
    {
        // Instantiate the bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Rotate the bullet to face the joystick direction
        float angle = Mathf.Atan2(joystickDirection.y, joystickDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle - 90); // Adjust angle if needed to align with your sprite
    }
}
