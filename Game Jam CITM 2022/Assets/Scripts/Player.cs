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

    private Vector2 speed = new Vector2 (5,7);
    private bool canJump = true;
    public bool hasSteamWeapon = false;
    private bool canSteamJump = false;

    lookingAt orientation = lookingAt.RIGHT;
    public bulletType currentBullet = bulletType.DEFAULT;

    public float bulletSwapCoolDown = 1;
    private float bulletSwapTimer;

    public float defaultBulletCoolDown = 0.25f;
    private float defaultBulletTimer;

    public float iceBulletCoolDown = 1.5f;
    private float iceBulletTimer;

    public float fireBulletCoolDown = 0.5f;
    private float fireBulletTimer;
   
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletSwapTimer = bulletSwapCoolDown;
    }

   
    void Update()
    {
       if(bulletSwapTimer > 0) bulletSwapTimer -= Time.deltaTime;
       if (defaultBulletTimer > 0) defaultBulletTimer -= Time.deltaTime;
       if (iceBulletTimer > 0) iceBulletTimer -= Time.deltaTime;
        if (fireBulletTimer > 0) fireBulletTimer -= Time.deltaTime;

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
                rb.velocity = new Vector2(rb.velocity.x, speed.y * 1.5f);
                canSteamJump = false;
            }
        }
        
        if(Input.GetMouseButtonDown(0))
        {
             Shoot(currentBullet, orientation);
        }
        if(Input.GetKeyDown("1"))
        {
            SwapBullet(bulletType.DEFAULT);
        }
        if (Input.GetKeyDown("2"))
        {
            SwapBullet(bulletType.ICE);
        }
        if (Input.GetKeyDown("3"))
        {
            SwapBullet(bulletType.FIRE);
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
                if(defaultBulletTimer <= 0)
                {
                    Instantiate(proyectile, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
                    defaultBulletTimer = defaultBulletCoolDown;
                }
                
            }
            if(bullet == bulletType.ICE)
            {
                if (iceBulletTimer <= 0)
                {
                    Instantiate(IceProyectile, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
                    iceBulletTimer = iceBulletCoolDown;
                }
            }
            if (bullet == bulletType.FIRE)
            {
                if (fireBulletTimer <= 0)
                {
                    Instantiate(FireProyectile, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
                    fireBulletTimer = fireBulletCoolDown;
                }
            }
        }
        if (direction == lookingAt.LEFT)
        {
            if (bullet == bulletType.DEFAULT)
            {
                if(defaultBulletTimer <= 0)
                {
                    Instantiate(proyectile, new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity);
                    defaultBulletTimer = defaultBulletCoolDown;
                }
            }
            if (bullet == bulletType.ICE)
            {
                if(iceBulletTimer <= 0)
                {
                    Instantiate(IceProyectile, new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity);
                    iceBulletTimer = iceBulletCoolDown;
                }
            }
            if (bullet == bulletType.FIRE)
            {
                if(fireBulletTimer <= 0)
                {
                    Instantiate(FireProyectile, new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y), Quaternion.identity);
                    fireBulletTimer = fireBulletCoolDown;
                }
            }
        }



    }
    private void SwapBullet(bulletType type)
    {
        if (bulletSwapTimer <= 0)
        {
            currentBullet = type;
            bulletSwapTimer = bulletSwapCoolDown;
        }
    }
}
