using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer; 
    public int damageOfFireBall = 1;
    // Case of Monster moves 
    public bool toTheDown ;

    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(toTheDown){
                transform.Translate(Vector2.down * 4f * Time.deltaTime);
        }else{
                rigidBody.velocity = -transform.right * speed;   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.transform.CompareTag("MainPlayer")){
            LifeScript playerHealth = collision.transform.GetComponent<LifeScript>();
            playerHealth.TakeDamage(damageOfFireBall);
            Destroy(gameObject);
        } 
    }


    private  void OnTriggerEnter2D(Collider2D collider){
        if((collider.name =="Wall") | (collider.tag=="Wall")){
            Destroy(gameObject);
        }
    }

}
