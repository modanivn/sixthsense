using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCheck : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public float endGameDistance = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (player.transform.position, monster.transform.position);
        if(distance <= endGameDistance){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
