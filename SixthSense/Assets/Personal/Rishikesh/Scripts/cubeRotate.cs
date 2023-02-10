using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRotate : MonoBehaviour
{
    public float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    void onTriggerEnter(Collider other) {
        Debug.Log("Inside Cube Triggerrrrrrr");
        speed = 150f;
    }
}
