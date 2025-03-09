using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingUIBackground : MonoBehaviour
{

    public RectTransform background; // The RectTransform of the background
    public Transform player;         // Reference to the player's Transform
    public float backgroundSpeedMultiplier = 0.5f; // Multiplier to control the background's parallax speed

    private Vector3 lastPlayerPosition;

    void Start()
    {
        // Store the initial position of the player
        lastPlayerPosition = player.position;
    }

    void Update()
    {
        // Calculate the player's movement delta
        Vector3 playerDelta = player.position - lastPlayerPosition;

        // Scroll the background based on the player's movement
        background.anchoredPosition -= new Vector2(playerDelta.x, playerDelta.y) * backgroundSpeedMultiplier;

        // Update the last player position
        lastPlayerPosition = player.position;
    }
}




