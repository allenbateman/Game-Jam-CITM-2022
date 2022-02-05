using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBossState
{
    FOLLOW,
    ATTACK,
    GROWL,
    NONE
}

public class Boss : MonoBehaviour
{
    private EBossState m_State;
    private bulletType m_EffectiveBullet;

    private Sprite[] m_FollowSprites;
    private Sprite[] m_AttackSprites;
    private Sprite[] m_GrowlSprites;

    private Animation[] m_Animations;

    private SpriteRenderer m_SR;

    private Player m_Player;

    private float m_DistanceAttack = 3f;
    private float m_MoveSpeed = 2.0f;

    private float m_AttackSpeed = 2f;
    private float m_AttackTimer = 0.0f;

    private float m_AttackArea = 4f;
    private float m_GrowlArea = 6f;

    void Start()
    {
        m_SR = GetComponent<SpriteRenderer>();

        m_State = EBossState.GROWL;

        m_Animations = new Animation[(int)EBossState.NONE];
        //m_Animations[(int)EBossState.ATTACK] = new Animation(m_AttackSprites, 0.5f, m_SR);
        //m_Animations[(int)EBossState.GROWL] = new Animation(m_GrowlSprites, 0.5f, m_SR);
        //m_Animations[(int)EBossState.FOLLOW] = new Animation(m_FollowSprites, 0.5f, m_SR);

        m_Player = FindObjectOfType<Player>();
    }

    void Update()
    {
        switch (m_State)
        {
            case EBossState.ATTACK:
                Attack();
                break;
            case EBossState.FOLLOW:
                Follow();
                break;
            case EBossState.GROWL:
                Growl();
                break;
        }
    }

    void Follow()
    {
        // Take difference in X axis
        float diff = m_Player.transform.position.x - transform.position.x;

        // Take direction in X axis
        float dirX = diff / Mathf.Abs(diff);

        // Take direction in X axis
        float distance = Mathf.Abs(diff);

        // Move towards player in X axis
        transform.position += Vector3.right * m_MoveSpeed * Time.deltaTime * dirX;

        if(distance < m_DistanceAttack)
        {
            m_State = EBossState.ATTACK;
        }
    }

    void Attack()
    {
        m_AttackTimer += Time.deltaTime;

        if (m_AttackTimer >= m_AttackSpeed)
        {
            // TODO: Do animation and kill on-hit
            //m_Animations[(int)EBossState.ATTACK].Update();

            //if (m_Animations[(int)EBossState.ATTACK].Finished())
            //{
            //    m_AttackTimer = 0;
            //    // TODO: Kill player
            //}
        }
        else
        {
            // Take distance in X axis
            float distance = Mathf.Abs(m_Player.transform.position.x - transform.position.x);

            if (distance > m_DistanceAttack)
            {
                m_State = EBossState.FOLLOW;
            }
        }
    }

    void Growl()
    {
        // TODO: Do animation
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
