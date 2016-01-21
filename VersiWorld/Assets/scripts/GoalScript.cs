using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    LevelTrackerScript levelTracker;

	// Use this for initialization
	void Start () {
        levelTracker = FindObjectOfType<LevelTrackerScript>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Moving to next level...");
            levelTracker.nextLevel();
        }
    }
}
