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
            player.GetComponent<StackingPrototype3_Level1>().checkEndCondition();
            // nextScenePanel.alpha = 1f;
            nextLevelCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void nextScene() {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        // nextScenePanel.alpha = 0f;
    }
}
