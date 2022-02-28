using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamageScript : MonoBehaviour
{    
public GameObject objectToDestroy;
public AudioClip sound; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("MainPlayer")){
            AudioManagerScript.instance.PlayClipAt(sound,transform.position);
            LifeScript playerHealth = collision.transform.GetComponent<LifeScript>();
            Destroy(objectToDestroy);
            playerHealth.TakeDamage(1);
        }
    } 

}
