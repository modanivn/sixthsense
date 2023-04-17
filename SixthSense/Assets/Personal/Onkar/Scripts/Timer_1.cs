using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer_1 : MonoBehaviour
{
    // public float timer = 5.0f;
    // public GameObject[] gameObjects;
    // public Canvas EndGame;
    // public TextMeshProUGUI timerText;

    // private void Start()
    // {
    //     EndGame.gameObject.SetActive(false);
    // }

    // void Update()
    // {
    //     timer -= Time.deltaTime;
    //     timerText.text = "Time left: " + Mathf.RoundToInt(timer);

    //     if (timer <= 0)
    //     {
    //         foreach (GameObject g in gameObjects)
    //         {
    //             g.SetActive(false);
    //         }
    //         EndGame.gameObject.SetActive(true);
    //     }
    // }

    public float timer = 60.0f;
    public GameObject[] gameObjects;
    public Canvas Game;
    public TextMeshProUGUI timerText;

    void Update()
    {
        timer -= Time.deltaTime;
        //timerText.text = "Time left: " + Mathf.RoundToInt(timer);
        
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timer <= 0)
        {
            foreach (GameObject g in gameObjects)
            {
                g.SetActive(false);
            }
            Game.gameObject.SetActive(true);
        }
    }
}
