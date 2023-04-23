using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guidance : MonoBehaviour
{
    public GameObject panel;
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !hasTriggered)
        {
            // Time.timeScale = 0f; // Pause the game time
            panel.SetActive(true); // Show the panel
            hasTriggered = true; // Set the flag to true
        }
    }

    void Update()
    {
        if (hasTriggered && Input.anyKeyDown)
        {
            panel.SetActive(false); // Hide the panel
            // Time.timeScale = 1f; // Resume the game time
        }
    }

}
