using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 speed = new Vector2 (5,5);
    public bool canJump = true;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

   
    void Update()
    {
        
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed.x,rb.velocity.y);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed.x, rb.velocity.y);
        }
        if (Input.GetKey("space") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed.y);
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = true;
    }
}
