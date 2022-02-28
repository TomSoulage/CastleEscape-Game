using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
    private string difficulty = "Easy";
    public static DifficultyScript instance; 

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        if(instance!=null) {
            return;
        }    

        instance = this; 
    }

    public void setDifficulty(string diff){
           difficulty = diff;      
    }

    public string getDifficulty(){
        return difficulty;
    }
}
