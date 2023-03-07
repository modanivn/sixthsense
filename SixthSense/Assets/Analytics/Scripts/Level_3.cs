using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level_3
{
    // Start is called before the first frame update
    public int totalNumberOfPowerups;
    public int totalNumberOfFreeze;
    public int totalNumberOfHits;
    public int totalNumberOfFalls;
    public float timeToComplete;
    public bool isComplete;
    public string hitLocations;

    public string fallLocation;

    public int bulletsShot;
    //public int cubesCollected;
    public Level_3(int totalNumberOfFreeze, int totalNumberOfHits, int totalNumberOfFalls, float timeToComplete, bool isComplete, string hitLocations, string fallLocation, int bulletsShot)
    {
        this.totalNumberOfFreeze = totalNumberOfFreeze;
        this.totalNumberOfHits = totalNumberOfHits;
        this.totalNumberOfFalls = totalNumberOfFalls;
        this.timeToComplete = timeToComplete;
        this.totalNumberOfPowerups = this.totalNumberOfFreeze;
        this.isComplete = isComplete;
        this.hitLocations = hitLocations;
        this.fallLocation = fallLocation;
        this.bulletsShot = bulletsShot;
        //this.cubesCollected = cubesCollected;
    }
}

