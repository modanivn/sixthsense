using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedMonsterTrigger_L2 : MonoBehaviour
{
    // public CanvasGroup nextScenePanel2;
    [SerializeField] GameObject nextLevelCanvas;
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<CubeLogic>().checkEndCondition();
            // nextScenePanel2.alpha = 1f;
            nextLevelCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void nextScene() {
        SceneManager.LoadScene(4);
    }
}
