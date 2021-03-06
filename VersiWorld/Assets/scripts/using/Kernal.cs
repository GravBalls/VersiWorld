﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Kernal : MonoBehaviour 
{
    public static List<Target> targets;
    public bool GameOver = false;

    GenerateTargets genTargets;
    TimeUI timer;
    [HideInInspector]
    public Player player;
    Image youLose;
    [SerializeField]
    Sprite winAsset;

    void Awake()
    {
        genTargets = GetComponentInChildren<GenerateTargets>();
        targets = genTargets.Generate();
        timer = GameObject.FindObjectOfType<TimeUI>();
        player = GameObject.FindObjectOfType<Player>();
        youLose = GameObject.FindWithTag("YouLose").GetComponent<Image>();
        Debug.Assert(youLose.name == "YouLose");
    }

    void Update()
    {
        if (targets.Count == 0)
        {
            timer.isRunning = false;
            GameOver = true;
            youLose.sprite = winAsset;
            youLose.enabled = true;
        }                       
        else if(!player.IsAlive)
        {
            GameOver = true;
            youLose.enabled = true;
        }

        if (GameOver)
        {
            //Debug.Log("we dead.");
        }


    }
}
