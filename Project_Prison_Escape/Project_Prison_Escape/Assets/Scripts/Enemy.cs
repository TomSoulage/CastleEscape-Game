using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth; 
    public Animator animator;
    public AudioClip deadSound; 
    public int nbOfDamage;
    public bool canRunAndAttack;
    public bool isWaitingToAttack;

    void Start()
    {
        currentHealth = maxHealth;    
    }

    void Update(){
        if((canRunAndAttack) && (!isWaitingToAttack)){
            Attack();
        }
    }

    public void Attack(){
        isWaitingToAttack = true; 
        animator.SetTrigger("Attack");
        StartCoroutine(waitToAttack(2f));
    }
    // Update is called once per frame
    public void TakeDamage(int d)
    {
        currentHealth -= d;
        animator.SetTrigger("TakeHit");

        if(currentHealth <=0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead",true);
        AudioManagerScript.instance.PlayClipAt(deadSound,transform.position);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false; 
        StartCoroutine(waitForDie(1.5f));
    }

    IEnumerator waitForDie(float seconds){
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
        StatsPlayerScript playerPoint = StatsPlayerScript.instance.GetComponent<StatsPlayerScript>();
        playerPoint.addPoint();
    }    

     IEnumerator waitToAttack(float seconds){
        yield return new WaitForSeconds(seconds);
        isWaitingToAttack = false; 
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(nbOfDamage != 0){
            if(collision.transform.CompareTag("MainPlayer")){
                LifeScript playerHealth = collision.transform.GetComponent<LifeScript>();
                playerHealth.TakeDamage(nbOfDamage); 
            }
        }
  
    }
}
