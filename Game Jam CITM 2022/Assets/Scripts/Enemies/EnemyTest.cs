using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyTest : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        state = EnemyState.PATROL;
        currentPatrolPoint = 0;
        GetOrientation();
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
                break;
            case EnemyState.FOLLOW:
                break;
            case EnemyState.ATTACK:
                break;
            case EnemyState.DEAD:
                anim.SetBool("Dead", true);

                break;
            default:
                break;
        }
    }

    protected override void Move()
    {
        GetOrientation();
        if (orientation == 1)
        {
            renderer.flipX = true;
            body.velocity = new Vector2(speed * orientation, 0);

        }
        else if(orientation == -1)
        {
            renderer.flipX = false;
            body.velocity = new Vector2(speed * orientation, 0);
        }
    }

    protected override void Patrol()
    {
   
        float dist = transform.position.x - patrolPoints[currentPatrolPoint].position.x;

        if (dist < 0.1f  && dist > -0.1f)
        {
          
            orientation *= -1;
            currentPatrolPoint++;
            if(currentPatrolPoint >= patrolPoints.Count)
            {
                currentPatrolPoint = 0;
            }
            state = EnemyState.IDLE;
            anim.SetBool("Idle", true);
            anim.SetBool("Patrol", false);
        }
    }

    protected override IEnumerator Wait(float time)
    {

        yield return new WaitForSeconds(time);
        state = EnemyState.PATROL;
        anim.SetBool("Idle", false);
        anim.SetBool("Patrol", true);
    }

    void  GetOrientation()
    {
        float dist = patrolPoints[currentPatrolPoint].position.x - transform.position.x;
        if(dist < 0)
        {
            orientation = -1;
        }else if(dist > 0)
        {
            orientation = 1;
        }
    }
}
