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
    public TextMeshProUGUI powerUpTextElement;
    public float powerUpTime = 10.0f;

    public void funWithCube(int index){
        
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
        powerUpTextElement.text = "Bridge Fast";
    }

    public void bridgeRotateDecreaseSpeed(){
        bridge.GetComponent<BridgeRotate>().decreaseSpeed(rotateSpeedMultiplier);
        powerUpTextElement.text = "Bridge Slow";
    }

    public void jumpForceIncrease(){
        gameObject.GetComponent<Player_Movement>().addForce(jumpForceMultiplier);
        powerUpTextElement.text = "Jump Increase";
        InvokeRepeating("UpdateCountdown",0.0f,1.0f);
        StartCoroutine(jumpForceDecrease());
    }

    void UpdateCountdown(){
        powerUpTextElement.text = "Jump increased for " + Mathf.CeilToInt(powerUpTime).ToString() + " seconds.";
        powerUpTime -= 1.0f;
    }

    public IEnumerator jumpForceDecrease(){
        yield return new WaitForSeconds(powerUpTime);
        CancelInvoke("UpdateCountdown");
        powerUpTextElement.text = "";
        powerUpTime = 10.0f;
        gameObject.GetComponent<Player_Movement>().decreaseForce(jumpForceMultiplier);
    }
}

