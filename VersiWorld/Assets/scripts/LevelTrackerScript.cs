using UnityEngine;
using System.Collections;

public class LevelTrackerScript : MonoBehaviour {

    public bool ignoreNextLevelCalls = false;
    public bool debugControlsAllowed = false;
    public bool readFromLevelKernal = false;

    public float levelTransitionDelay = 2.0f;
    float transitionTime = 0.0f;
    bool transitionActive = false;

    //int initLevel = 0;
    int firstLevel = 1;
    int lastLevel = 7;

    int currentLevel;
    Kernal currentKernal = null;

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

        if (readFromLevelKernal)
        {
            if (currentKernal != null && currentKernal.GameOver && !transitionActive)
            {
                transitionActive = true;
                transitionTime = levelTransitionDelay;
                Debug.Log("Level End Detected, Transition in: " + levelTransitionDelay + " Seconds.");
            }
        }

        if (transitionActive)
        {
            transitionTime -= Time.deltaTime;
            if (transitionTime <= 0.0f)
            {
                if (currentKernal.player.IsAlive)
                {
                    Debug.Log("Level Complete Detected");
                    nextLevel();
                }
                else
                {
                    Debug.Log("Level Failure Detected");
                    resetLevel();
                }
                transitionActive = false;
            }
        }
    }

    void OnLevelWasLoaded()
    {
        if (readFromLevelKernal)
        {
            currentKernal = FindObjectOfType<Kernal>();
            Debug.Log("New Kernal Connected");
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
