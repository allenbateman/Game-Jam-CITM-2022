using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum EnemyState
{
   IDLE,
   PATROL,
   FOLLOW,
   ATTACK,
   DEAD
}

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D body;
    protected SpriteRenderer renderer;
    protected EnemyState  state;
    [SerializeField]
    protected int hitPoints;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float attackCD;
    [SerializeField]
    protected float detectionDistance;
    [SerializeField]
    protected List<Transform> patrolPoints;

    protected int currentPatrolPoint;

    protected int orientation;

    public void TakeDamage(int amount)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
            state = EnemyState.DEAD;

    }

    protected virtual void Move()
    { 

    }
    
    protected virtual void Follow()
    {

    }

    protected virtual void Patrol()
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void Die()
    {
        //when finish death animation 
        Debug.Log("Im dead");
        Destroy(gameObject);
    }

}
