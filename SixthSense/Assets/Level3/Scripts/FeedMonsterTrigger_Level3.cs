using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedMonsterTrigger_Level3 : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<StackingPrototype3_Level3>().checkEndCondition();
        }
    }
}
