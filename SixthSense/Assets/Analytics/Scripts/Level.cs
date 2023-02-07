using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isComplete;
    public float timeToComplete;
    public Level(bool isComplete, float timeToComplete)
    {
        this.isComplete = isComplete;
        this.timeToComplete = timeToComplete;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
