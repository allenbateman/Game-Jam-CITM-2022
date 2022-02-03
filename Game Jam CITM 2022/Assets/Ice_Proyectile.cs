using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Proyectile : MonoBehaviour
{
    private GameObject player;
    private Vector2 speed;
    public int secondsToDestroy = 5;
    private Rigidbody2D rb;
    private float deathTimer;

    [SerializeField]
    int damage;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathTimer = 0;

        rb = gameObject.GetComponent<Rigidbody2D>();
        if (gameObject.transform.position.x > player.transform.position.x)
        {
            speed = new Vector2(6.5f, 0);
        }
        if (gameObject.transform.position.x < player.transform.position.x)
        {
            speed = new Vector2(-6.5f, 0);
        }
    }


    void FixedUpdate()
    {
        deathTimer += Time.deltaTime;
        rb.velocity = speed;
        if (deathTimer >= secondsToDestroy)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
            //collision.transform.GetComponent<Enemy>().TakeDamage(damage);
        

        Destroy(gameObject);
    }
}
