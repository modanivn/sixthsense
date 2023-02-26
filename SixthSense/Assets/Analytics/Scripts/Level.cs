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
    //public int cubesCollected;
    public Level(int totalNumberOfJumps, int totalNumberOfFreeze, int totalNumberOfHits, float timeToComplete)
    {
        this.totalNumberOfJumps = totalNumberOfJumps;
        this.totalNumberOfFreeze = totalNumberOfFreeze;
        this.totalNumberOfHits = totalNumberOfHits;
        this.timeToComplete = timeToComplete;
        //this.cubesCollected = cubesCollected;
    }

    public void addNumberOfPowerups() {
        totalNumberOfPowerups = totalNumberOfFreeze + totalNumberOfJumps;
    }

    public int getTotalNumberOfPowerups() {
        return totalNumberOfPowerups;
    }
}
