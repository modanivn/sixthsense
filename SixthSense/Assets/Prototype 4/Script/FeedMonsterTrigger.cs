using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedMonsterTrigger : MonoBehaviour
{
    // public CanvasGroup nextScenePanel;
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
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
