using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("MainPlayer")){
                    animator.SetTrigger("Elevating");
        }
    } 
}
