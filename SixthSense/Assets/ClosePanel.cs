using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject pauseCanvas;

    void Update()
    {
        if (currentPanel.activeSelf)
        {
            
            // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                Debug.Log("key pressed!!!!");
                // Deactivate the panel
                currentPanel.SetActive(false);
                pauseCanvas.SetActive(true);
                Debug.Log("after pause panellll");
                Time.timeScale = 1f;
            }
            else {
                Time.timeScale = 0f;
            }
        }
    }
}
