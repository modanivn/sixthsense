using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedMonsterTrigger : MonoBehaviour
{
    public CanvasGroup nextScenePanel;
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<StackingPrototype3>().checkEndCondition();
            nextScenePanel.alpha = 1f;
        }
    }
    public void nextScene() {
        SceneManager.LoadScene(0);
        nextScenePanel.alpha = 0f;
    }
}
