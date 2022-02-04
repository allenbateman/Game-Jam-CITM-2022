using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bulletType
{
    DEFAULT,
    ICE,
    FIRE
}
public class proyectile : MonoBehaviour
{
    private GameObject player;
    private Vector2 speed;
    private Rigidbody2D rb;
    private float deathTimer;
    [SerializeField]
    int damage;
    [SerializeField]
    float proyectileSpeed;
    [SerializeField]
    int secondsToDestroy;
    [SerializeField]
    bulletType Type;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

    
    void FixedUpdate()
    {
        deathTimer += Time.deltaTime;
        rb.velocity = speed;
        if(deathTimer >= secondsToDestroy)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
            collision.transform.GetComponent<Enemy>().TakeDamage(damage);

        if(collision.transform.tag != "Sensor")
            Destroy(gameObject);
    }
}
