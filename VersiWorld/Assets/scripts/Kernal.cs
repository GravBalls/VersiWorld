using UnityEngine;
using System.Collections.Generic;

public class Kernal : MonoBehaviour 
{
    public static List<Target> targets;

    GenerateTargets genTargets;
    TimeUI timer;

    void Awake()
    {
        genTargets = GetComponentInChildren<GenerateTargets>();
        targets = genTargets.Generate();
        timer = GameObject.FindObjectOfType<TimeUI>();
    }

    void Update()
    {
        if (targets.Count == 0)
        {
            timer.isRunning = false;
        }


    }
}
