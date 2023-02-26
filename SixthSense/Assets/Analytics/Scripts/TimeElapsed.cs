using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class TimeElapsed : MonoBehaviour
{
    // Start is called before the first frame update
    public static Stopwatch _stopWatch = new Stopwatch();

    public static void startTime()
    {
        _stopWatch.Start();
    }

    public static void subtractTime()
    {
        _stopWatch.SubtractTime(5.0f);
    }

    public static void endTime()
    {
        _stopWatch.Stop();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
