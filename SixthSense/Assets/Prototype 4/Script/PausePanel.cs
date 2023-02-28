using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    public void Pause() {
        TimeElapsed.endTime();
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume() {
        TimeElapsed.startTime();
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
