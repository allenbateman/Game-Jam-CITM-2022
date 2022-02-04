using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFlower : Enemy
{
    [SerializeField]
    GameObject bulletPrefab;
    Transform sideFirePoint;
    Transform upFirePoint;
    [SerializeField]
    float bulletForce = 1;
    [SerializeField]
    float fireRate = 1;
    float currentTime;
    bool Shooting = false;
    [SerializeField]
    bool VerticalShoot;

    IEnumerator IsShooting;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        state = EnemyState.IDLE;
        sideFirePoint = transform.GetChild(0).GetComponent<Transform>();
        upFirePoint = transform.GetChild(1).GetComponent<Transform>();
        orientation = -1;
        currentTime = 0;
        VerticalShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(orientation);
        if (orientation == 1)
            gameObject.transform.Rotate( new Vector2(0,-180));
        else if(orientation == -1)
            gameObject.transform.Rotate(new Vector2(0, 0));

        switch (state)
        {
            case EnemyState.IDLE:
                StopCoroutine("Wait");
                break;
            case EnemyState.PATROL:
                break;
            case EnemyState.FOLLOW:
                break;
            case EnemyState.ATTACK:
                anim.SetBool("Attack", true);
                currentTime -= Time.deltaTime;
                if(currentTime <= 0)
                {
                    Shoot();
                    currentTime = fireRate;
                }
                 break;
            case EnemyState.DEAD:
                Die();
                anim.SetBool("Dead", true);
                break;
            default:
                break;
        }
    }

    private void Shoot()
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.rotation = transform.rotation;
     
        if(VerticalShoot)
        {
            obj.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
            obj.transform.position = upFirePoint.position;
        }
        else
        {
            obj.GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
            obj.transform.position = sideFirePoint.position;
        }
    }
}
