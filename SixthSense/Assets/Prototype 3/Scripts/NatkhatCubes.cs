using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatkhatCubes : MonoBehaviour
{
    private int[] functionArray = {1,2,3,4};
    public GameObject bridge;
    public float rotateSpeedMultiplier = 5.0f;
    public float jumpForceMultiplier = 1.5f;

    public void funWithCube(GameObject currentCube){
        System.Random random = new System.Random();
        int index = random.Next(1, functionArray.Length+1);
        
        switch(index){
            case 1:
            bridgeRotateIncreaseSpeed();
            break;

            case 2:
            bridgeRotateDecreaseSpeed();
            break;

            case 3:
            jumpForceIncrease();
            break;

            case 4:
            jumpForceDecrease();
            break;
        }
    }

    public void bridgeRotateIncreaseSpeed(){
        bridge.GetComponent<BridgeRotate>().increaseSpeed(rotateSpeedMultiplier);
    }

    public void bridgeRotateDecreaseSpeed(){
        bridge.GetComponent<BridgeRotate>().decreaseSpeed(rotateSpeedMultiplier);
    }

    public void jumpForceIncrease(){
        gameObject.GetComponent<Player_Movement>().addForce(jumpForceMultiplier);
    }

    public void jumpForceDecrease(){
        gameObject.GetComponent<Player_Movement>().decreaseForce(jumpForceMultiplier);
    }
}
