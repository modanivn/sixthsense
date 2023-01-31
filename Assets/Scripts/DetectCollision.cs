using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // GameObject g;
        // for (var i = other.transform.childCount-1; i>=0; i--){
        //     for (var j = )
        //     Destroy(other.transform.GetChild(i).gameObject);
        // } 
        var j  = other.transform.GetChild(0);
        for (var i = j.transform.childCount-1; i>=0; i--){
            
            Destroy(j.transform.GetChild(i).gameObject);
        } 
        // Destroy(gameObject);
        // Destroy(other.gameObject);
    }
}
