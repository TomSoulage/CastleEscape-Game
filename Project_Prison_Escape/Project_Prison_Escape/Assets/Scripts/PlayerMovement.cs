using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform groundCheck;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float groundCheckRadius; 
    public LayerMask collisionLayers; 
    public static PlayerMovement instance;     
    public bool isAttackFinish;
    public float attackRange = 0.5f;
    public int damageOfAttack = 1;
    public AudioClip attackSound; 
    public AudioClip jumpSound; 

    private bool isJumping ;
    private bool isGrounded; 
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    public static bool beginGame =true;
    private void Awake(){
        
        if(instance!=null){
            return;
        }
        instance = this; 
    }

    public void isTheBeginning(){
        beginGame = true; 
    }
    void Update(){

        if(beginGame){
            TimerController.instance.BeginTimer();
            beginGame = false;
        }

        horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        Flip(rigidBody.velocity.x);

        float characterVelocity = Mathf.Abs(rigidBody.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

        //Jump
        if( Input.GetButtonDown("Jump") && (isGrounded)){
            isJumping = true; 
        }
                   
        if(Input.GetKeyDown(KeyCode.F) && !isAttackFinish ){
            Attack();    
        } 

    }

    void Attack(){

        isAttackFinish=true;
        
        AudioManagerScript.instance.PlayClipAt(attackSound,transform.position);

        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
            
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damageOfAttack);
            Debug.Log("We hit " + enemy.name);
        } 
        StartCoroutine(EnableAttack(0.5f));

    }

    
    IEnumerator EnableAttack(float seconds){
        yield return new WaitForSeconds(seconds);
        isAttackFinish = false;
    }
    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,collisionLayers);
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float horizontalMovement){
        Vector3 targetVelocity = new Vector3(horizontalMovement, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity,targetVelocity,ref velocity, .06f);
        
        if((isJumping == true)){
            AudioManagerScript.instance.PlayClipAt(jumpSound,transform.position);
            rigidBody.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {      

    }

    void Flip(float velocity)
    {   
        if(velocity > 0.1f)
        {
                        spriteRenderer.flipX = true; 

        }else if(velocity <-0.1f)
        {
            spriteRenderer.flipX = false; 

        }

    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
        if(attackPoint==null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

}
