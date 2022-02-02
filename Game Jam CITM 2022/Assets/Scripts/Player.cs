using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum lookingAt
{
    RIGHT,
    LEFT
};
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject proyectile;
    public Vector2 speed = new Vector2 (5,5);
    public bool canJump = true;

    lookingAt orientation = lookingAt.RIGHT;
    
    
   
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

   
    void Update()
    {
        
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed.x,rb.velocity.y);
            orientation = lookingAt.RIGHT;
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed.x, rb.velocity.y);
            orientation = lookingAt.LEFT;
        }
        if (Input.GetKey("space") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed.y);
            canJump = false;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(orientation == lookingAt.RIGHT)
            {
                Instantiate(proyectile, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
            }
           if(orientation == lookingAt.LEFT)
            {
                Instantiate(proyectile, new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = true;
    }
    public Vector2 GetPosition()
    {
        Vector2 ret = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        
        return ret;
    }
}
