using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 offset = new Vector3(0, 4, -7);
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player!= null)
        {
            transform.position = player.transform.position + offset;
        }
        
        
    }
}
