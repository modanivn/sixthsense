using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NatkhatCubes : MonoBehaviour
{
    private int[] functionArray = {1,2,3,4};
    public GameObject bridge;
    public float rotateSpeedMultiplier = 5.0f;
    public float jumpForceMultiplier = 1.5f;
    public TextMeshProUGUI textElement;

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
        textElement.text = "Bridge Fast";
    }

    public void bridgeRotateDecreaseSpeed(){
        bridge.GetComponent<BridgeRotate>().decreaseSpeed(rotateSpeedMultiplier);
        textElement.text = "Bridge Slow";
    }

    public void jumpForceIncrease(){
        gameObject.GetComponent<Player_Movement>().addForce(jumpForceMultiplier);
        textElement.text = "Jump Increase";
    }

    public void jumpForceDecrease(){
        gameObject.GetComponent<Player_Movement>().decreaseForce(jumpForceMultiplier);
        textElement.text = "Jump Decrease";
    }
}
