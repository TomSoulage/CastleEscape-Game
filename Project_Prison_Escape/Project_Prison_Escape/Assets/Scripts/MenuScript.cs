using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string level;
    public GameObject settingsWindow;
    public GameObject helpWindow;

    public  void StartGame()
    {
        SceneManager.LoadScene(level);
    }

    public void Settings(){
        settingsWindow.SetActive(true);
    }
    
    public void CloseSettings(){
        settingsWindow.SetActive(false);
    }
    // Update is called once per frame
    public void Help()
    {
        helpWindow.SetActive(true);
    }

    public void CloseHelp(){
        helpWindow.SetActive(false);
    }


    public void LoadCredit(){
        SceneManager.LoadScene("Credits");
    }
    public void Exit(){
        Application.Quit();
    }



}
