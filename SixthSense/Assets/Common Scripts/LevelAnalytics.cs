using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelAnalytics
{
    public int totalNumberOfPowerups;
    public int totalNumberOfFreeze;
    public int totalNumberOfJumps;
    public int totalNumberOfHits;
    public int totalNumberOfFalls;
    public float timeToComplete;
    public bool isComplete;
    public string hitLocations;
    public string fallLocation;
    public int bulletsShot;

    public LevelAnalytics(int totalNumberOfJumps, int totalNumberOfFreeze, int totalNumberOfHits, int totalNumberOfFalls, float timeToComplete, bool isComplete, string hitLocations, string fallLocation, int bulletsShot)
    {
        this.totalNumberOfJumps = totalNumberOfJumps;
        this.totalNumberOfFreeze = totalNumberOfFreeze;
        this.totalNumberOfHits = totalNumberOfHits;
        this.totalNumberOfFalls = totalNumberOfFalls;
        this.timeToComplete = timeToComplete;
        this.totalNumberOfPowerups = this.totalNumberOfFreeze + this.totalNumberOfJumps;
        this.isComplete = isComplete;
        this.hitLocations = hitLocations;
        this.fallLocation = fallLocation;
        this.bulletsShot = bulletsShot;
    }
    public static string formatHitLocations(List<List<float>> hitLocations) {
        return string.Join("\n", hitLocations.Select(row => "[" + string.Join(", ", row.Select(item => item.ToString()).ToArray()) + "],").ToArray());
    }
}
