using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    public GameObject secondDoor = null;
    private GameObject player;
    [SerializeField]
    int activationDistance;
    public bool isActive;
    private float distanceToPlayer;
    public bool hasSecondDoor = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if(distanceToPlayer < activationDistance)
        {
            if(Input.GetKeyDown("e"))
            {
                isActive = !isActive;
                door.transform.GetComponent<Door>().UnLock();
                if(hasSecondDoor)
                {
                    secondDoor.transform.GetComponent<Door>().UnLock();
                }
            }
        }
    }
    public void ResetState()
    {
        isActive = false;
    }
}
