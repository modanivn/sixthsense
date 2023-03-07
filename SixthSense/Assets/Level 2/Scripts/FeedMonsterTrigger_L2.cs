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
            player.GetComponent<Stacking_level_2>().checkEndCondition();
            // nextScenePanel2.alpha = 1f;
            nextLevelCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void nextScene() {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
        // nextScenePanel2.alpha = 0f;
    }
}
