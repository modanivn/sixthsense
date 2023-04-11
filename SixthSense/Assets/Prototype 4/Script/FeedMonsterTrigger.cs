using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedMonsterTrigger : MonoBehaviour
{
    public int nextSceneToLoad = 6;
    // public CanvasGroup nextScenePanel;
    [SerializeField] GameObject nextLevelCanvas;
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<CubeLogic>().checkEndCondition();
            nextLevelCanvas.SetActive(true);
            Screen.lockCursor = false;
            Time.timeScale = 0f;
        }
    }
    public void nextScene() {
        SceneManager.LoadScene(nextSceneToLoad);
        Time.timeScale = 1f;
    }
}
