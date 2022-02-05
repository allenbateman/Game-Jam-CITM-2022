using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bulletType
{
    DEFAULT,
    ICE,
    FIRE,
    NONE
}



public class proyectile : MonoBehaviour
{
    private GameObject player;
    private Vector2 speed;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private float deathTimer;
    [SerializeField]
    int damage;
    [SerializeField]
    float proyectileSpeed;
    [SerializeField]
    int secondsToDestroy;
    [SerializeField]
    bulletType Type;
    [SerializeField]
    GameObject fireEffectPrefab;
    [SerializeField]
    GameObject iceEffectPrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collider = GetComponent<BoxCollider2D>();
        deathTimer = 0;
      
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (gameObject.transform.position.x > player.transform.position.x)
        {
            speed = new Vector2(proyectileSpeed, 0);
        }
        if(gameObject.transform.position.x < player.transform.position.x)
        {
            speed = new Vector2(-proyectileSpeed, 0);
        }
    }

    private void Update()
    {
        deathTimer += Time.deltaTime;
        if (rb != null)
            rb.velocity = speed;
       
        if (deathTimer >= secondsToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        { 
            collision.transform.GetComponent<Enemy>().TakeDamage(damage, Type);
            if (Type == bulletType.FIRE)
            {
                Instantiate(fireEffectPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    public bulletType GetBulletType()
    {
        return Type;
    }

    void SetCollider()
    {
        collider.enabled = true;
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
