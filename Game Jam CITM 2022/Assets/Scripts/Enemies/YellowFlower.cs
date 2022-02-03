using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFlower : Enemy
{
    GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        state = EnemyState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.IDLE:
                StartCoroutine(Wait(2));
                break;
            case EnemyState.PATROL:
                Move();
                Patrol();
                break;
            case EnemyState.FOLLOW:
                break;
            case EnemyState.ATTACK:
                break;
            case EnemyState.DEAD:
           //     anim.SetBool("Dead", true);
                break;
            default:
                break;
        }
    }

    private void Shoot()
    {

    }
}
