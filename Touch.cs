using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public float carSpeed = 5f;       // Speed of the player's movement
    public float maxPosX = 2f;       // Horizontal boundary
    public float maxPosY = 3.85f;    // Vertical boundary
    public Joystick joystick;        // Drag the joystick component in the Inspector

    private Vector3 position;

    public GameObject bulletPrefab;  // Drag the bullet prefab in the Inspector
    public Transform firePoint;      // Assign the fire point (an empty GameObject)
    public float bulletSpeed = 10f;  // Adjust the bullet speed
    public float fireCooldown = 0.5f; // Cooldown between each bullet

    private float lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position; // Initialize the position of the player
    }

    // Update is called once per frame
    void Update()
    {
        // Get joystick input
        float horizontal = joystick.Horizontal; // Horizontal input
        float vertical = joystick.Vertical;     // Vertical input

        // Update position based on joystick input
        position.x += horizontal * carSpeed * Time.deltaTime;
        position.y += vertical * carSpeed * Time.deltaTime;

        // Clamp the position within the defined boundaries
        position.x = Mathf.Clamp(position.x, -maxPosX, maxPosX);
        position.y = Mathf.Clamp(position.y, -maxPosY, maxPosY);

        // Apply the updated position to the player
        transform.position = position;

        // Check if joystick is being moved and shoot automatically
        if ((horizontal != 0 || vertical != 0) && Time.time >= lastFireTime + fireCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        lastFireTime = Time.time;

        // Instantiate the bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Apply velocity to the bullet to make it move forward
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = firePoint.up * bulletSpeed; // Move the bullet forward in the fire point's up direction
        }
    }
}
