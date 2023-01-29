using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float x,y,z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary vector
     Vector3 temp = player.transform.position;
     temp.x = temp.x + x;
     temp.y = temp.y + y;
     // Assign value to Camera position
     transform.position = temp;
    }
}
