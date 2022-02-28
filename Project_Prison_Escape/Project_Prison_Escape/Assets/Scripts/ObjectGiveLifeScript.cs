using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGiveLifeScript : MonoBehaviour
{
public AudioClip sound; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("MainPlayer")){
            LifeScript playerHealth = collision.transform.GetComponent<LifeScript>();
            if(playerHealth.getLife()<3){
                AudioManagerScript.instance.PlayClipAt(sound,transform.position);
                Destroy(gameObject);
                playerHealth.addLife(1);
            }
        }
    } 
}
