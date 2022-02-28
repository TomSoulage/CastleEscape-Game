using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaArea : MonoBehaviour
{
    private Transform playerSpawn;    

    private void OnTriggerEnter2D (Collider2D collision){
        if(collision.CompareTag("MainPlayer")){
            LifeScript playerHealth = collision.transform.GetComponent<LifeScript>();
            playerHealth.TakeDamage(3);
        }
    }

}
