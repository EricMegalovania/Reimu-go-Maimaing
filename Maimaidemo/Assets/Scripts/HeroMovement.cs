using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public bool isOnGround=false;
    public float SpeedX=6.0f;
    public float AssumeFriction=0.15f;
    public float JumpY=15.0f;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        float xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * SpeedX,rb.velocity.y);
        */
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(SpeedX,rb.velocity.y);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-SpeedX,rb.velocity.y);
        }
        if(!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
        {
            Vector2 p=rb.velocity;
            if(p.x>AssumeFriction) p.x-=AssumeFriction;
            else if(p.x<-AssumeFriction) p.x+=AssumeFriction;
            else p.x=0;
            rb.velocity = p;
        }
    }
    void Update()
    {
        if(rb.IsTouchingLayers(groundLayer))
        {
            Debug.Log("1111");
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
        if(isOnGround&&Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 p=rb.velocity;
            p.y=JumpY;
            rb.velocity=p;
        }
    }
}
