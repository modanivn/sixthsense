using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level_2
{
    // Start is called before the first frame update
    public int totalNumberOfPowerups;
    public int totalNumberOfJumps;
    public int totalNumberOfFalls;
    public float timeToComplete;
    public bool isComplete;
    //public int cubesCollected;
    public Level_2(int totalNumberOfJumps, int totalNumberOfFalls, float timeToComplete, bool isComplete)
    {
        this.totalNumberOfJumps = totalNumberOfJumps;
        this.totalNumberOfFalls = totalNumberOfFalls;
        this.timeToComplete = timeToComplete;
        this.totalNumberOfPowerups = this.totalNumberOfJumps;
        this.isComplete = isComplete;
        //this.cubesCollected = cubesCollected;
    }
}

