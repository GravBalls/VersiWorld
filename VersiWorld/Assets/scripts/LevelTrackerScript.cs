﻿using UnityEngine;
using System.Collections;

public class LevelTrackerScript : MonoBehaviour {

    public bool ignoreNextLevelCalls = false;
    public bool debugControlsAllowed = false;

    //int initLevel = 0;
    int firstLevel = 1;
    int lastLevel = 3;

    int currentLevel;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        currentLevel = 0;
        Debug.Log("Loading First Level...");
        nextLevel();
	}

    void Update() {//consistent 
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading Level...");
            resetLevel();
        }
        //debug only
        if (debugControlsAllowed)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Forcing Next Level...");
                nextLevel();
            }
        }
    }

    public void nextLevel() {
        if (ignoreNextLevelCalls)
        {
            Debug.Log("Level Transition Refused");
            return;
        }

        currentLevel++;

        if (currentLevel > lastLevel)
        {
            currentLevel = firstLevel;
            Debug.Log("Returning to First Level...");
        }

        Application.LoadLevel(currentLevel);
        Debug.Log("Next Level Loaded");
    }

    public void resetLevel() {
        Application.LoadLevel(currentLevel);
        Debug.Log("Level Reloaded");
    }
}