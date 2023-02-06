using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRotate : MonoBehaviour
{
    public float rotateSpeed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    public void increaseSpeed(float multiplier){
        rotateSpeed = rotateSpeed * multiplier;
        rotateSpeed = Mathf.Min(200.0f,rotateSpeed);
    }

    public void decreaseSpeed(float multiplier){
        rotateSpeed = rotateSpeed / multiplier;
        rotateSpeed = Mathf.Max(4.0f,rotateSpeed);
    }

}
