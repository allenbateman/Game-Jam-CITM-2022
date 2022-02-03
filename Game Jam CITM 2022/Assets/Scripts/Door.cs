using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isActive = false;
    private GameObject player;
    [SerializeField]
    int activationDistance;
    private float distanceToPlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
            if (distanceToPlayer < activationDistance)
            {
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("You have passed through the door");
                }
            }
        }
    }

    public void UnLock()
    {
        isActive = !isActive;
    }

}
