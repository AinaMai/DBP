using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 600f; // Adjust the speed as needed
    public Joystick joystick;
    private Rigidbody2D rb;

    public BoxCollider2D backgroundCollider; // Assign the background collider in the Inspector
    private Vector2 minBounds;
    private Vector2 maxBounds;

    public GameObject bulletPrefab; // Drag the bullet prefab in the Inspector
    public Transform firePoint;     // Assign the fire point (an empty GameObject)
    public float bulletSpeed = 10f; // Adjust the bullet speed
    public float fireCooldown = 0.5f; // Cooldown between each bullet

    private float lastFireTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the bounds of the background collider
        if (backgroundCollider != null)
        {
            Bounds bounds = backgroundCollider.bounds;
            minBounds = bounds.min;
            maxBounds = bounds.max;
        }
        else
        {
            Debug.LogWarning("Background Collider not assigned!");
        }
    }

    void FixedUpdate()
    {
        // Get movement direction from joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        // Calculate new position
        Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;

        // Clamp the position within the collider bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        // Apply the clamped position
        rb.MovePosition(newPosition);

        // Check if joystick is being moved and shoot automatically
        if (direction != Vector2.zero && Time.time >= lastFireTime + fireCooldown)
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
