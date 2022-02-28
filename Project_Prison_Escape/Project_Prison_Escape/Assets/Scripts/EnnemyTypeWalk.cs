using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTypeWalk : MonoBehaviour
{
    public float speed; 
    public Transform[] waypoints;
    
    public int nbOfDamage;
    public SpriteRenderer spriteRenderer; 
    private Transform target; 
    private int destPoint = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Direction 
        Vector3 dir = target.position - transform.position;
        //Movement
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // If ennemy is nearly arring at destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f )
        {
                destPoint = (destPoint + 1) % waypoints.Length;
                target = waypoints[destPoint];
                transform.RotateAround(transform.position,transform.up,180f);
                //spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("MainPlayer")){
            LifeScript playerHealth = collision.transform.GetComponent<LifeScript>();
            playerHealth.TakeDamage(nbOfDamage); 
        }
    }

 
}
