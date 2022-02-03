using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum lookingAt
{
    RIGHT,
    LEFT
};

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject proyectile;
    public GameObject IceProyectile;
    public GameObject FireProyectile;
    public Vector2 speed = new Vector2 (5,5);
    private bool canJump = true;
    public bool hasSteamWeapon = true;
    private bool canSteamJump = true;
    lookingAt orientation = lookingAt.RIGHT;
    public bulletType currentBullet = bulletType.DEFAULT;
    
   
    
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
        if (Input.GetKeyDown("space"))
        {
            if (canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed.y);
                canJump = false;
            }
            else if (canSteamJump)
            { 
                rb.velocity = new Vector2(rb.velocity.x, speed.y * 2f);
                canSteamJump = false;
            }
        }
        
        if(Input.GetMouseButtonDown(0))
        {
             Shoot(currentBullet, orientation);
        }
        if(Input.GetKeyDown("1"))
        {
            currentBullet = bulletType.DEFAULT;
        }
        if (Input.GetKeyDown("2"))
        {
            currentBullet = bulletType.ICE;
        }
        if (Input.GetKeyDown("3"))
        {
            currentBullet = bulletType.FIRE;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            if (hasSteamWeapon) canSteamJump = true;
        }
    }
    private void Shoot(bulletType bullet, lookingAt direction)
    {
        if(direction == lookingAt.RIGHT)
        {
            if (bullet == bulletType.DEFAULT)
            {
                Instantiate(proyectile, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
            }
            if(bullet == bulletType.ICE)
            {
                Instantiate(IceProyectile, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
            }
            if (bullet == bulletType.FIRE)
            {
                Instantiate(FireProyectile, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
            }
        }
        if (direction == lookingAt.LEFT)
        {
            if (bullet == bulletType.DEFAULT)
            {
                Instantiate(proyectile, new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity);
            }
            if (bullet == bulletType.ICE)
            {
                Instantiate(IceProyectile, new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity);
            }
            if (bullet == bulletType.FIRE)
            {
                Instantiate(FireProyectile, new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity);
            }
        }



    }
}
