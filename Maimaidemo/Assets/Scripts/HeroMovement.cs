using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public bool isOnGround=false;
    private Animator anim;
    private bool isJumping=false;
    public float SpeedX=6.0f;
    public float AssumeFriction=0.15f;
    public float JumpY=15.0f;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        float xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * SpeedX,rb.velocity.y);
        */
        if(rb.IsTouchingLayers(groundLayer))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(SpeedX,rb.velocity.y);
            Debug.Log("DDD");
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-SpeedX,rb.velocity.y);
            Debug.Log("AAA");
        }
        if(!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
        {
            Vector2 p=rb.velocity;
            if(p.x>AssumeFriction) {
                p.x-=AssumeFriction;
            } 
            else if(p.x<-AssumeFriction) {
                p.x+=AssumeFriction;
            }
            else 
            {
                p.x=0;
            }
            rb.velocity = p;
        }
        
    }
    void Update()
    {
        if(isOnGround&&Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 q=rb.velocity;
            q.y=JumpY;
            rb.velocity=q;
            isOnGround=false;
            isJumping=true;
        }
        Vector2 p=rb.velocity;
        if(p.x>AssumeFriction) transform.localRotation = Quaternion.Euler(0,0,0);
        if(p.x<-AssumeFriction) transform.localRotation = Quaternion.Euler(0,180,0);
        if(isOnGround)
        {
            if(isJumping) isJumping=false;
            else if(p.x>AssumeFriction*15.0f) {
                anim.SetBool("run",true);
                anim.SetBool("idle",false);
                anim.SetBool("jump",false);
                anim.SetBool("fall",false);
            } 
            else if(p.x<-AssumeFriction*15.0f) {
                anim.SetBool("run",true);
                anim.SetBool("idle",false);
                anim.SetBool("jump",false);
                anim.SetBool("fall",false);
            }
            else 
            {
                anim.SetBool("run",false);
                anim.SetBool("idle",true);
                anim.SetBool("jump",false);
                anim.SetBool("fall",false);
            }
        }
        else
        {
            if(p.y>=0.6f) 
            {
                anim.SetBool("run",false);
                anim.SetBool("idle",false);
                anim.SetBool("jump",true);
                anim.SetBool("fall",false);
            }
            else if(p.y<=-0.6f){
                anim.SetBool("run",false);
                anim.SetBool("idle",false);
                anim.SetBool("jump",false);
                anim.SetBool("fall",true);
            }
            else {
                anim.SetBool("run",false);
                anim.SetBool("idle",true);
                anim.SetBool("jump",false);
                anim.SetBool("fall",false);
            }
        }
    }
}
