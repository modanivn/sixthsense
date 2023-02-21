using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        
        Invoke("DestroyObject", 6.0f);
    }

    

    public void DestroyObject()
    {
       
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
