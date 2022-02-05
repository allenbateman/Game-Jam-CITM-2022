using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum EnemyState
{
   IDLE,
   PATROL,
   FROZEN,
   FOLLOW,
   ATTACK,
   DEAD
}

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D body;
    protected SpriteRenderer renderer;
    protected Animator anim;
    [HideInInspector]
    public EnemyState  state;
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

    [SerializeField]
    private SpriteRenderer effectObject;

    protected float freezeTime = 8.0f;
    protected float freezeTimer = 0;

    protected float idleTime = 2.0f;
    protected float idleTimer = 0;

    protected Animation freezeAnimation;
    [SerializeField]
    protected Sprite[] freezeSprites;

    protected int currentPatrolPoint;

    [HideInInspector]
    public int orientation;

    protected bool DoDamage;
    protected bool IsFrozen;

    protected virtual void Start()
    {
        freezeAnimation = new Animation(freezeSprites, 0.5f, effectObject);
    }

    public void OnBulletHit(proyectile p)
    {
    }

    public void TakeDamage(int amount, bulletType type)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
            state = EnemyState.DEAD;

        if(type == bulletType.ICE)
        {
            state = EnemyState.FROZEN;

            anim.SetBool("Frozen", true);
            effectObject.gameObject.SetActive(true);

            freezeTimer = 0;
            freezeAnimation.Reset();
        }
    }

    protected virtual void Idle()
    {

    }

    protected virtual void Move()
    { 

    }
    
    protected virtual void Follow()
    {

    }

    protected virtual void Frozen()
    {
        body.velocity = Vector2.zero;
        freezeTimer += Time.deltaTime;

        if (freezeTimer >= freezeTime)
        {
            freezeAnimation.Update();

            if (freezeAnimation.Finished())
            {
                Unfreeze();
            }
        }
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

    protected virtual IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public int GetHitPoints() { return hitPoints; }

    protected void Unfreeze()
    {
        anim.SetBool("Frozen", false);
        state = EnemyState.IDLE;
        freezeAnimation.Reset();
        freezeTimer = 0;
        effectObject.gameObject.SetActive(false);
    }

}
