using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TimerController : MonoBehaviour
{
    public static TimerController instance; 
    public Text timeCounter; 
    private TimeSpan timePlaying; 
    private bool timerGoing; 
    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        timeCounter.text = "00:00:00";
        timerGoing = false; 
        
    }

    public void BeginTimer()
    {
        timerGoing = true; 
        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }

    public String EndTimer()
    {
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
        timerGoing = false;
        return timePlayingStr;
    }

    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elapsedTime += Time.deltaTime; 
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

}
