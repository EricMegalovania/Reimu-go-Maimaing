using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public bool IfJumping=false;
    public float SpeedX=6.0f;
    public float JumpY=15.0f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * SpeedX,rb.velocity.y);
    }
    void Update()
        {
            if(!IfJumping&&Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 p=rb.velocity;
                p.y=JumpY;
                rb.velocity=p;
                IfJumping=true;
            }
        }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 p=rb.velocity;
        if(IfJumping&&p.y==0) 
        {
            IfJumping=false;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Vector3 p=rb.velocity;
        if(IfJumping&&p.y==0) 
        {
            IfJumping=false;
        }
    }
}
