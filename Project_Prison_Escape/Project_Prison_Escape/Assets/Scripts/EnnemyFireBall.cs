using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFireBall : MonoBehaviour
{
    public GameObject fireBall;
    public Transform firePoint;

    public float delayOfSpit = 5f;
    private bool isWaiting;

    void Update(){
        if(!isWaiting){
            SpitFireBall();
        }

       
    }

    public void SpitFireBall(){
        isWaiting = true; 
        Instantiate(fireBall,firePoint.position,firePoint.rotation);
        StartCoroutine(wait(delayOfSpit));
    }

    IEnumerator wait(float seconds){
        yield return new WaitForSeconds(seconds);
        isWaiting = false;
    }
}
