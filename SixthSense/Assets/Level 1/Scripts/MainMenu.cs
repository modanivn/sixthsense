using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void sensitivitySetting() {
        SceneManager.LoadScene(1);
    }

    public void PlayGame() {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;

    }
}
