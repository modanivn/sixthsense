using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStack : MonoBehaviour
{
    public int value;
    public Color pickupColor;
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent <Renderer>();
        rend.material.SetColor("_Color",pickupColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
