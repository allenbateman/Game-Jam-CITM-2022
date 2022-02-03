using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Lever : MonoBehaviour
{
    public GameObject door_01;
    public GameObject door_02;
    public GameObject door_03;
    public GameObject lever_01;
    public GameObject lever_02;
    public GameObject lever_03;

    private GameObject player;
    [SerializeField]
    int activationDistance;
    //public bool isActive;
    private float distanceToPlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distanceToPlayer < activationDistance)
        {
            if (Input.GetKeyDown("e"))
            {
               
                door_01.transform.GetComponent<Door>().ResetPosition();
                door_02.transform.GetComponent<Door>().ResetPosition();
                door_03.transform.GetComponent<Door>().ResetPosition();

                lever_01.transform.GetComponent<Lever>().ResetState();
                lever_02.transform.GetComponent<Lever>().ResetState();
                lever_03.transform.GetComponent<Lever>().ResetState();
            }
        }
    }
}
