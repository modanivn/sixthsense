using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformMovement : MonoBehaviour
{
    public float moveRange = 2.0f;
    public float moveSpeed = 1.0f;
    public float maxHeight = 2.0f;
    private Vector3 startPosition;
    private bool goingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (goingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            if (transform.position.y >= startPosition.y + maxHeight)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;

            if (transform.position.y <= startPosition.y)
            {
                goingUp = true;
            }
        }
    }
}