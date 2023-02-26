using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    // Start is called before the first frame update
    public int totalNumberOfPowerups;
    public int totalNumberOfFreeze;
    public int totalNumberOfJumps;
    public int totalNumberOfHits;
    public float timeToComplete;
    public boolean isLevelCompleted;
    //public int cubesCollected;
    public Level(int totalNumberOfJumps, int totalNumberOfFreeze, int totalNumberOfHits, float timeToComplete, boolean isLevelCompleted)
    {
        this.totalNumberOfJumps = totalNumberOfJumps;
        this.totalNumberOfFreeze = totalNumberOfFreeze;
        this.totalNumberOfHits = totalNumberOfHits;
        this.timeToComplete = timeToComplete;
        this.isLevelCompleted = isLevelCompleted;
        //this.cubesCollected = cubesCollected;
    }
}
