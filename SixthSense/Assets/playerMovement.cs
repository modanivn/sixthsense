using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = .03f;
    public float pSpeed;
    private Vector3 rotation;

    void Start() {
        pSpeed = 0f;
        rotation = new Vector3(5.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, yDirection);
        transform.position += moveDirection * speed;
    }

    void OnTriggerEnter(Collider other) {
        // Debug.Log("Player OnTriggerEnter");
        // Debug.Log(other.name);

        if(other.gameObject.tag == "Cube") {
            Debug.Log(other.transform.parent.gameObject.name);
            
            other.transform.parent.Rotate(rotation * Time.deltaTime * pSpeed);
        }
    }
}
