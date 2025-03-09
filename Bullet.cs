using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;          // Speed of the bullet
    public float lifetime = 5f;      // Time before the bullet is destroyed
    public bool hasAnimation = false; // Toggle if animation is used

    private void Start()
    {
        // Destroy the bullet after its lifetime to prevent memory leaks
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet forward (in the local "up" direction of the GameObject)
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Optional: Add a condition if you want animation toggled
        if (hasAnimation)
        {
            AnimateBullet();
        }
    }

    private void AnimateBullet()
    {
        // Example: Simple rotation animation
        transform.Rotate(Vector3.forward, 360f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet hits an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Notify the enemy to take damage
            collision.GetComponent<Enemy>()?.TakeDamage();

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}


