using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject winUI; 
   public static WinScript instance;    

    private void Awake(){
        
        if(instance!=null){
            return;
        }
        instance = this; 
    }


   public void whenPlayerWin(){
        winUI.SetActive(true);
        StatsPlayerScript.instance.takeFinalPoint();
        StatsPlayerScript.instance.takeFinalTime();
        PlayerMovement.instance.enabled = false;
    }
    public void RetryGame(){
        winUI.SetActive(false);
        LifeScript.instance.Respawn();
        KeepDataOnLoad.instance.RemoveFromKeepDataOnLoad();
        SceneManager.LoadScene("Level1");
    }

    public void MainMenuButton(){
        KeepDataOnLoad.instance.RemoveFromKeepDataOnLoad();
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame(){
        Application.Quit();
    }
}
