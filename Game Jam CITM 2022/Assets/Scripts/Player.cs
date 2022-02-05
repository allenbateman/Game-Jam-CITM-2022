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
    bool IsShooting;

    private string currentAnimation;

    private string RUN_ANIMAITON = "Run";
    private string RUN_GUN_ANIMAITON = "RunGun";
    private string IDLE_ANIMAITON = "Idle";
    private string IDLE_GUN_ANIMAITON = "IdleGun";
    private string SHOT_VAPOR_ANIMAITON = "ShotVapor";
    private string SHOT_ICE_ANIMAITON = "ShotIce";
    private string SHOT_FIRE_ANIMAITON = "ShotFire";
    private string JUMP_ANIMAITON = "Jump";
    private string DOUBLE_JUMP_ANIMAITON = "DoubleJump";
    private string RECOVERY_ANIMAITON = "Recovery";
    private string DEAD_ANIMAITON = "Dead";
    



    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletSwapTimer = bulletSwapCoolDown;
        anim = GetComponent<Animator>();
        firePoint = transform.GetChild(0);
        OnAir = false;
        IsShooting = false;
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
             rb.velocity = new Vector2(0, rb.velocity.y);           
        }
        if (Input.GetKeyDown("space") && !IsShooting)
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
                    GameObject obj = Instantiate(proyectile);
                    obj.transform.position = firePoint.position;
                    obj.transform.rotation = transform.rotation;
                    defaultBulletTimer = defaultBulletCoolDown;
                }
                
            }
            else if(currentBullet == bulletType.ICE)
            {
                if (iceBulletTimer <= 0)
                {

                    GameObject obj = Instantiate(IceProyectile);
                    obj.transform.position = firePoint.position;
                    obj.transform.rotation = transform.rotation;
                    iceBulletTimer = iceBulletCoolDown;
                }
            }
            else if (currentBullet == bulletType.FIRE)
            {
                if (fireBulletTimer <= 0)
                {
                    GameObject obj = Instantiate(FireProyectile);
                    obj.transform.position = firePoint.position;
                    obj.transform.rotation = transform.rotation;
                    fireBulletTimer = fireBulletCoolDown;
                }
            }

        IsShooting = false;
    }

    public float getDefaultBulletCd()
    {
        return defaultBulletCoolDown;
    }

    public float getDefaultBulletTimer()
    {
        return defaultBulletTimer;
    }

    public float getIceBulletCd()
    {
        return iceBulletCoolDown;
    }

    public float getIceBulletTimer()
    {
        return iceBulletTimer;
    }

    public float getFireBulletCd()
    {
        return fireBulletCoolDown;
    }

    public float getFireBulletTimer()
    {
        return fireBulletTimer;
    }

    public bulletType getCurrentBullet()
    {
        return currentBullet;
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
        IsShooting = true;
    }
    private void SetGun()
    {
        anim.SetBool("HasGun", true);
    }

    void ChangeAnimationState(string newAnimation)
    {
        anim.Play(newAnimation);
    }
}
