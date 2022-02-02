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
    [SerializeField]
    Rigidbody2D body;
    protected EnemyState  state;
    [SerializeField]
    protected int hitPoints;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float attackCD;
    [SerializeField]
    protected float detectionDistance;

    public void TakeDamage(int amount)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
            state = EnemyState.DEAD;

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

    }

}
