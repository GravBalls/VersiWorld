using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Kernal : MonoBehaviour 
{
    public static List<Target> targets;
    public static bool GameOver = false;

    GenerateTargets genTargets;
    public static Player player;
    Image youLose;

    void Awake()
    {
        DontDestroyOnLoad(this);

        genTargets = GetComponentInChildren<GenerateTargets>();
        targets = genTargets.Generate();
        player = GameObject.FindObjectOfType<Player>();
        youLose = GameObject.FindWithTag("YouLose").GetComponent<Image>();
        Debug.Assert(youLose.name == "YouLose");
    }

    void Update()
    {
        if (targets.Count == 0)
        {
            TimeUI.isRunning = false;
            GameOver = true;
            
        }                       
        else if(!player.IsAlive)
        {
            TimeUI.isRunning = false;
            GameOver = true;
            youLose.enabled = true;
        }

        if (GameOver)
        {
            KillTargets();
            Debug.Log("we dead.");
        }


    }

    public static void KillTargets()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            Destroy(targets[i].gameObject);
        }
        targets.Clear();
    }
}
