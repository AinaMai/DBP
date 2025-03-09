using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessBackgroundScroller : MonoBehaviour
{
    public Transform[] backgrounds; // Array to hold both background images
    public float scrollSpeed = 2f; // Speed of the background scroll
    public Camera mainCamera;      // Reference to the camera
    private float backgroundHeight;

    void Start()
    {
        // Assume all backgrounds have the same height
        backgroundHeight = backgrounds[0].GetComponent<RectTransform>().rect.height;
    }

    void Update()
    {
        // Scroll each background
        foreach (var bg in backgrounds)
        {
            bg.position += Vector3.down * scrollSpeed * Time.deltaTime;

            // If a background moves out of the camera's view, reposition it to the top
            if (bg.position.y <= -backgroundHeight)
            {
                bg.position += new Vector3(0, 2 * backgroundHeight, 0);
            }
        }
    }
}


