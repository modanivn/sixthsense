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
    public int totalNumberOfFalls;
    public float timeToComplete;
    public bool isComplete;
    //public int cubesCollected;
    public Level(int totalNumberOfJumps, int totalNumberOfFreeze, int totalNumberOfHits, int totalNumberOfFalls, float timeToComplete, bool isComplete)
    {
        this.totalNumberOfJumps = totalNumberOfJumps;
        this.totalNumberOfFreeze = totalNumberOfFreeze;
        this.totalNumberOfHits = totalNumberOfHits;
        this.totalNumberOfFalls = totalNumberOfFalls;
        this.timeToComplete = timeToComplete;
        this.totalNumberOfPowerups = this.totalNumberOfFreeze + this.totalNumberOfJumps;
        this.isComplete = isComplete;
        //this.cubesCollected = cubesCollected;
    }

    // public void addNumberOfPowerups() {
    //     totalNumberOfPowerups = totalNumberOfFreeze + totalNumberOfJumps;
    // }

    // public int getTotalNumberOfPowerups() {
    //     return ;
    // }
}
