using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FeedMonsterTrigger_Level1 : MonoBehaviour
{
    // public CanvasGroup nextScenePanel;
    // public CanvasGroup gameOverPanel;
    [SerializeField] GameObject nextLevelCanvas;
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<CubeLogic>().checkEndCondition();
            nextLevelCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void nextScene() {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
}
