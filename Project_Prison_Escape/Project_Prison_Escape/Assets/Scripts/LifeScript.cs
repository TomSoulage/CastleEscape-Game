using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead; 
    public bool isInvicible = false; 
    public float invicibilityDelay = 0.2f; 
    public SpriteRenderer spriteRenderer; 

    public static LifeScript instance;    
    public AudioClip hitSound; 
    private bool beginGame = true; 
    private string difficulty =  "Easy" ;
    private void Awake(){
        
        if(instance!=null){
            return;
        }
        instance = this;
    }
    private void Start()
    {   
        if(beginGame){
            difficulty = DifficultyScript.instance.getDifficulty();
            switch(difficulty){
                case "Easy" :
                    Debug.Log("Easy difficulty");
                    life = hearts.Length;    
                    foreach(GameObject obj in hearts) {
                        obj.SetActive(true);
                    } 
                break;
                case "Medium" :
                    Debug.Log("Medium difficulty");
                    life = hearts.Length-1;    
                    hearts[2].SetActive(false);
                    hearts[1].SetActive(true);
                    hearts[0].SetActive(true);
                break;
                case "Hard" :
                    Debug.Log("Hard difficulty");
                    life = hearts.Length-2;    
                    hearts[2].SetActive(false);
                    hearts[1].SetActive(false);
                    hearts[0].SetActive(true);
                break;
                default :
                    life = hearts.Length;    
                    foreach(GameObject obj in hearts) {
                        obj.SetActive(true);
                    } 
                break;
            }

            beginGame = false;
        }
  
    }
    void Update(){
       if(dead==true){
                //GAME OVER
        } 
    }

    public void TakeDamage(int d){
        if(life >=1){
           //animator.SetTrigger("TakeHit");
           AudioManagerScript.instance.PlayClipAt(hitSound,transform.position);
           while((life>0)&&(d>0)){ 
                life -=1;
                hearts[life].SetActive(false);
                d--;
            } 
            isInvicible = true; 
            StartCoroutine(waitAfterDamage());
            StartCoroutine(HandleInvicibilityDelay());
        }
        if(life<=0){
            Die();
        }
    }

    public void addLife(int d){
        if(life < 3){
            life +=1;
            hearts[life-1].SetActive(true);
        }
    }

    public int getLife(){
       return life;
    } 

    public IEnumerator waitAfterDamage(){
        while (isInvicible){
            //spriteRenderer.color = newFB5959 Color(224,82,82,255);
            spriteRenderer.color = new Color(0.823f,0.09f,0.17f,1f);
            yield return new WaitForSeconds(invicibilityDelay);
            spriteRenderer.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay(){
        yield return new WaitForSeconds(2.5f);
        spriteRenderer.color = new Color(1f,1f,1f,1f);
        isInvicible = false; 
    }
    
    public void Die(){
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Dead"); 
        PlayerMovement.instance.rigidBody.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rigidBody.velocity = Vector3.zero;
        GameOverScript.instance.whenPlayerDeath();   
    }
    public void Respawn(){
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rigidBody.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rigidBody.velocity = Vector3.zero;
        GameOverScript.instance.whenPlayerDeath();   
        life = 3;
    }



}
