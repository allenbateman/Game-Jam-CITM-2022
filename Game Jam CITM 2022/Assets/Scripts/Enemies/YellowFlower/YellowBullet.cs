using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBullet : MonoBehaviour
{
    [SerializeField]
    float despawnTimer = 1;

    [SerializeField]
    public float speed = 1;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //    rb.velocity = new Vector2(speed, 0);
  //     rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        despawnTimer -= Time.deltaTime;
        if (despawnTimer <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Touched Player");
            //do damage
            Destroy(gameObject);
        }

        if (collision.transform.tag != "Sensor")
            Destroy(gameObject);
    }
}
