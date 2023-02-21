using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed;
    [SerializeField] private bool isRotating;

    void Start() {
        speed = 0f;
        rotation = new Vector3(0.0f, 5.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime * speed);

    }

    // private void OnTriggerEnter(Collider other) {
    //     Debug.Log("Inside OnTriggerEnter()");
    //     Debug.Log(other.name);
    //     if(other.gameObject.tag == "Player") {
    //         if(!isRotating) {
    //             speed = 5f;
    //         }
                
    //         else {
    //             speed = 0f;
    //         }
                
    //         isRotating = !isRotating;
    //     }
            
    // }

}
