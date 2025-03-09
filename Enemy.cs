using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 3;    // Maximum health of the enemy
    private int currentHealth;  // Current health of the enemy

    private void Start()
    {
        // Set the current health to max health at the start
        currentHealth = maxHealth;
    }

    // Call this method when the enemy takes damage
    public void TakeDamage(int damage = 1)
    {
        // Reduce health
        currentHealth -= damage;

        // Check if the enemy's health is depleted
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Destroy the enemy object
        Destroy(gameObject);
    }
}


