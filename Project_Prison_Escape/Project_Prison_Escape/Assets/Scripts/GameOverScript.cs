using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI; 
    public static GameOverScript instance;    

    private void Awake(){
        
        if(instance!=null){
            return;
        }
        instance = this; 
    }
    public void whenPlayerDeath(){
        if(CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            KeepDataOnLoad.instance.RemoveFromKeepDataOnLoad();
        }
        TimerController.instance.EndTimer();
        gameOverUI.SetActive(true);
    }

    public void RetryGame(){
        gameOverUI.SetActive(false);
        LifeScript.instance.Respawn();
        KeepDataOnLoad.instance.RemoveFromKeepDataOnLoad();
        PlayerMovement.instance.isTheBeginning();
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
