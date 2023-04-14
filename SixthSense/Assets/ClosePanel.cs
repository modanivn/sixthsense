using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public GameObject pauseCanvas;

    void Update()
    {
        if (currentPanel.activeSelf)
        {
            Time.timeScale = 0f;
            if (Input.anyKeyDown)
            {
                currentPanel.SetActive(false);
                nextPanel.SetActive(true);
            }
        }

        else if(nextPanel.activeSelf) {
            if (Input.anyKeyDown)
            {
                nextPanel.SetActive(false);
                pauseCanvas.SetActive(true);
                Time.timeScale = 1f;
            }
            else {
                Time.timeScale = 0f;
            }
        }
    }
}
