using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int playerHealth;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite redHeart;  // Red heart sprite
    [SerializeField] private Sprite blackHeart;  // Black heart sprite

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        // Check if health is zero or below, trigger game restart or respawn
        if (playerHealth <= 0)
        {
            DestroyPlayer(); // Handle player destruction
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                // Heart is filled (player has health)
                hearts[i].sprite = redHeart; // Set the heart sprite to red
            }
            else
            {
                // Heart is empty (player is missing health)
                hearts[i].sprite = blackHeart; // Set the heart sprite to black
            }
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage; // Reduce health by the damage amount
        UpdateHealth();         // Update the health display

        if (playerHealth <= 0)
        {
            DestroyPlayer(); // Handle player destruction
        }
    }

    private void DestroyPlayer()
    {
        Debug.Log("Player destroyed!");
        // Add destruction or game over logic here
        Destroy(gameObject); // Destroy the player GameObject
    }
}
