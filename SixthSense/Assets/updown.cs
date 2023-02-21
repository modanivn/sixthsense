using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class updown : MonoBehaviour
{
    public float speed = 0.5f;
    public float distance = 2f;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}