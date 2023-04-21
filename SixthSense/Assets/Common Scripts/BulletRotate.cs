using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public Vector3 rotationCenter = Vector3.zero;
    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotationCenter, rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
