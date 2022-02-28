using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayerScript : MonoBehaviour
{
    private int playerPoints = 0 ;
    public Text playerPointsText;
    public Text playerFinalTimeText;
    public Text playerFinalPointsText;
    public static StatsPlayerScript instance; 
    private void Awake()
    {
        if(instance!=null) {
            return;
        }    

        instance = this; 
    }
    
    public void addPoint(){
        playerPoints++;
        playerPointsText.text = playerPoints.ToString();
    }

    public void takeFinalPoint(){
        playerFinalPointsText.text = playerPoints.ToString();
    }

    public void takeFinalTime(){
        playerFinalTimeText.text = TimerController.instance.EndTimer();
    }

}
