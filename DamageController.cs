using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5; // Maximum health of the enemy ship
    private int currentHealth;

    [SerializeField] private GameObject explosionEffect; // Optional explosion effect prefab

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for collision with projectiles or player
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(1); // Reduce health by 1 (can be customized per projectile)
            Destroy(collision.gameObject); // Destroy the projectile
        }
        else if (collision.CompareTag("Player"))
        {
            TakeDamage(maxHealth); // Instantly destroy the enemy when colliding with the player
            // Optionally, deal damage to the player here
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); // Handle enemy death
        }
    }

    private void Die()
    {
        if (explosionEffect != null)
        {
            // Instantiate explosion effect at the enemy's position
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Destroy the enemy ship
    }
}
