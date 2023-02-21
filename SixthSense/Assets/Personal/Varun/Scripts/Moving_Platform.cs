using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public float rightLimit = 2.5f;
    public float leftLimit = -2.5f;
    public float speed = 2.0f;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.z < leftLimit)
        {
            direction = 1;

        }

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
    }
    
}
