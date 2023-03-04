using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticItem : MonoBehaviour
{
    public GameObject platformPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = platformPosition.transform.position;
        transform.position = new Vector3(temp.x, temp.y + 0.4f, temp.z);
    }
}
