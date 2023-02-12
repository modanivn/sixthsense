using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBridgeTrigger : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<StackingPrototype3>().makeBridgeToMonster();
    }
}
