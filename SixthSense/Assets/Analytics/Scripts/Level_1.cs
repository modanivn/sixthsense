using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level_1
{
    // Start is called before the first frame update
    public int totalNumberOfFalls;
    public float timeToComplete;
    public bool isComplete;
    //public int cubesCollected;
    public Level_1(int totalNumberOfFalls, float timeToComplete, bool isComplete)
    {
        this.totalNumberOfFalls = totalNumberOfFalls;
        this.timeToComplete = timeToComplete;
        this.isComplete = isComplete;
        //this.cubesCollected = cubesCollected;
    }
}

