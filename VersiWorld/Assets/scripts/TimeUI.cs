using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeUI : MonoBehaviour 
{
    Text time;
    float timer = 0;
    public bool isRunning = true;
    

    void Awake()
    {
        time = GetComponent<Text>();
    }

    void Update()
    {
        if(isRunning)
        {
            timer += Time.deltaTime;
        }
        
        time.text = string.Format("TIME {0:c}", timer);
    }

    void StartTimer()
    {
        
    }
}
