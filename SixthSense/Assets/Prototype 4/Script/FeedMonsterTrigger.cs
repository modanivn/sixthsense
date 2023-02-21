using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedMonsterTrigger : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.GetComponent<StackingPrototype3>().checkEndCondition();
        }
    }
}
