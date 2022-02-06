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

    [SerializeField]
    Sprite open, closed;

    SpriteRenderer renderer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            renderer.sprite = open;
        }else
        {
            renderer.sprite = closed;
        }
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
