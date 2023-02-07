using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isComplete;
    public float timeToComplete;
    public int cubesCollected;
    public Level(bool isComplete, float timeToComplete, int cubesCollected)
    {
        this.isComplete = isComplete;
        this.timeToComplete = timeToComplete;
        this.cubesCollected = cubesCollected;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
