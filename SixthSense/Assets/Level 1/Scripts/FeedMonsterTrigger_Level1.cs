using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FeedMonsterTrigger_Level1 : MonoBehaviour
{
    public CanvasGroup nextScenePanel;
    // public CanvasGroup gameOverPanel;
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<StackingPrototype3_Level1>().checkEndCondition();
            nextScenePanel.alpha = 1f;
        }
    }

    public void nextScene() {
        SceneManager.LoadScene(2);
        nextScenePanel.alpha = 0f;
    }
}
