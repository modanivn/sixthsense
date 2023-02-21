using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    public void Pause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
