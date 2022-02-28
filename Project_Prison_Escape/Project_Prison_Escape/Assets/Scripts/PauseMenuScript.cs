using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool gameIsPaused = false; 

    public GameObject pauseMenuUI;
    
    public GameObject settingsWindow;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else{
                if((GameOverScript.instance.gameOverUI.activeSelf) | (WinScript.instance.winUI.activeSelf)){

                }else{
                    Paused();
                }
            }
        }
    }

    void Paused(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true ;
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false ;
    }

    public void LoadMenu()
    {
        KeepDataOnLoad.instance.RemoveFromKeepDataOnLoad();
        SceneManager.LoadScene("Menu");   
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

}
