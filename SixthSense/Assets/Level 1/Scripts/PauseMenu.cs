using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject sensitivityMenu;
    [SerializeField] GameObject controlsMenu;
    // [SerializeField] GameObject player;
    bool pauseGameToggle = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseGameToggle) 
            {
                Pause();
                Screen.lockCursor = false;
            } 
            else 
            {
                Resume();
                Screen.lockCursor = true;
            }
            pauseGameToggle = !pauseGameToggle;
        }
    }

    public void Pause() {
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
        // player.GetComponent<Player_Movement>().changeCameraToDefault();
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
