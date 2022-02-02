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
        state = EnemyState.PATROL;
        currentPatrolPoint = 0;
        orientation = -1;
    }

    // Update is called once per frame
    void Update()
    {
       
        switch (state)
        {
            case EnemyState.IDLE:
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
                //when dead anim finishes
                Die();
                break;
            default:
                break;
        }
    }

    protected override void Move()
    {
        if(orientation == 1)
        {
            renderer.flipX = false;
            body.velocity = new Vector2(speed * orientation, 0);

        }
        else if(orientation == -1)
        {
            renderer.flipX = true;
            body.velocity = new Vector2(speed * orientation, 0);
        }
    }

    protected override void Patrol()
    {
        //float dist = Vector2.Distance(transform.position, patrolPoints[currentPatrolPoint].position);
        float dist = transform.position.x - patrolPoints[currentPatrolPoint].position.x;
        Debug.Log(dist);
        if (dist < 0.1f  && dist > -0.1f)
        {
            orientation *= -1;
            currentPatrolPoint++;
            if(currentPatrolPoint >= patrolPoints.Count)
            {
                currentPatrolPoint = 0;
            }
        }
    }
}
