using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KeepDataOnLoad : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    public static KeepDataOnLoad instance;    

    private void Awake(){
        
        if(instance!=null){
            return;
        }
        instance = this;

          foreach(var element in objects)
        {
            DontDestroyOnLoad(element);
        } 
    }

    
    public void RemoveFromKeepDataOnLoad()
    {
        foreach(var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
