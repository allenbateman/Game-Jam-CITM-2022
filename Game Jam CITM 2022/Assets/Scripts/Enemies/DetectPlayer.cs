using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    GameObject flower;
    [SerializeField]
    int orientation;
    private void Start()
    {
        flower = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (flower.GetComponent<Enemy>().GetHitPoints() > 0)
            {
                flower.GetComponent<Enemy>().state = EnemyState.ATTACK;
                flower.GetComponent<Enemy>().orientation = orientation;
            }
            
        }
    }
}
