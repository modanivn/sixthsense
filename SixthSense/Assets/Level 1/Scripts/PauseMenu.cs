using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject sensitivityMenu;
    [SerializeField] GameObject controlsMenu;

    public void Pause() {
        Debug.Log("Inside Pause Menu");
        pauseMenu.SetActive(true);
        sensitivityMenu.SetActive(false);
        controlsMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(int sceneId) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneId);
    }
    public void Quit() {
        SceneManager.LoadScene(0);
    }
    public void OpenSensitivityCanvas() {
        sensitivityMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void OpenControlsCanvas() {
        controlsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
