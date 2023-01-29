using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed=20.0f;
    private float hspeed = 10.0f;
    private float verticalInput;
    private float horizontalInput;
    private float xRange = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);
        transform.Translate(horizontalInput * hspeed * Time.deltaTime * Vector3.right);
    }
}
