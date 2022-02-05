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
    Transform firePoint;
    Animator anim;

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

    private bool HasGun = false;
    bool OnAir;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletSwapTimer = bulletSwapCoolDown;
        anim = GetComponent<Animator>();
        firePoint = transform.GetChild(0);
        OnAir = false;
        Idle();

        HasGun = true;
        if (HasGun)
            SetGun();
    }


    void Update()
    {
       if(bulletSwapTimer > 0) bulletSwapTimer -= Time.deltaTime;
       if (defaultBulletTimer > 0) defaultBulletTimer -= Time.deltaTime;
       if (iceBulletTimer > 0) iceBulletTimer -= Time.deltaTime;
       if (fireBulletTimer > 0) fireBulletTimer -= Time.deltaTime;

        if (orientation == lookingAt.RIGHT)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0,0);
        }
        else if (orientation == lookingAt.LEFT)
        { 
            gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        }


        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed.x,rb.velocity.y);
            orientation = lookingAt.RIGHT;
            if (!OnAir)
                Run();
        }else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed.x, rb.velocity.y);
            orientation = lookingAt.LEFT;
            if (!OnAir)
                Run();
        }
        else
        {
            if (!OnAir)
            {
                Idle();
            }
             //rb.velocity = new Vector2(0, rb.velocity.y);
            
        }
        if (Input.GetKeyDown("space"))
        {
            if (canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed.y);
                canJump = false;
                OnAir = true;
                Jump();
            }
            else if (canSteamJump)
            { 
                rb.velocity = new Vector2(rb.velocity.x, speed.y);
                OnAir = true;
                canSteamJump = false;
            }
        }

        
        if(Input.GetMouseButtonDown(0))
        {
            ShootAnim((int)currentBullet);
            //Shoot();
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
            OnAir = false;
            if (hasSteamWeapon) canSteamJump = true;
        }
    }
    private void Shoot()
    {
 
            if (currentBullet == bulletType.DEFAULT)
            {
                if(defaultBulletTimer <= 0)
                {
                    Instantiate(proyectile, firePoint.position, Quaternion.identity);
                    defaultBulletTimer = defaultBulletCoolDown;
                }
                
            }
            else if(currentBullet == bulletType.ICE)
            {
                if (iceBulletTimer <= 0)
                {
                    Instantiate(IceProyectile, firePoint.position, Quaternion.identity);
                    iceBulletTimer = iceBulletCoolDown;
                }
            }
            else if (currentBullet == bulletType.FIRE)
            {
                if (fireBulletTimer <= 0)
                {
                    Instantiate(FireProyectile, firePoint.position, Quaternion.identity);
                    fireBulletTimer = fireBulletCoolDown;
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

    private void Run()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Shoot", false);
    }
    private void Idle()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Idle", true);
        anim.SetBool("Jump", false);
        anim.SetBool("Shoot", false);
    }
    private void Jump()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Jump", true);
        anim.SetBool("Shoot", false);
    }
    private void ShootAnim(int type)
    {
        anim.SetBool("Run", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Shoot", true);
        anim.SetInteger("GunType", type);
    }
    private void SetGun()
    {
        anim.SetBool("HasGun", true);
    }
}
