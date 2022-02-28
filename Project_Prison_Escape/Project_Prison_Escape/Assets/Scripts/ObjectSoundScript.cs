using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSoundScript : MonoBehaviour
{
    public AudioClip waterSound; 
    private bool isFirstContact = true;
    private  void OnTriggerEnter2D(Collider2D collider){
        if((collider.CompareTag("MainPlayer")) && (isFirstContact)){
            AudioManagerScript.instance.PlayClipAt(waterSound,transform.position);
            isFirstContact = false; 
        }
    }

}
