using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedMonsterTrigger_Level3 : MonoBehaviour
{
    // public CanvasGroup nextScenePanel;
    [SerializeField] GameObject nextLevelCanvas;
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<CubeLogic>().checkEndCondition();
            // nextScenePanel.alpha = 1f;
            nextLevelCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
     public void nextScene() {
        SceneManager.LoadScene(5);
        Time.timeScale = 1f;
        // nextScenePanel.alpha = 0f;
    }
}
