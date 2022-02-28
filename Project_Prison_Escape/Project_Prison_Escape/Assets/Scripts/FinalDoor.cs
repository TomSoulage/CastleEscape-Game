using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("MainPlayer")){
            WinScript.instance.whenPlayerWin();   
        }
    }
    
}
