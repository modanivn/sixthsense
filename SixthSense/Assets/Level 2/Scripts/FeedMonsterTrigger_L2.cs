using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedMonsterTrigger_L2 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<Stacking_level_2>().checkEndCondition();
        }
    }
}
