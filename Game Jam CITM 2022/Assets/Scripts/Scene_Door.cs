using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Door : MonoBehaviour
{
    public EScenes nextScene;
    private GameObject player;
    private GameObject manager;
    private int activationDistance = 2;
    private float distanceToPlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("Scene_Manager");
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distanceToPlayer < activationDistance)
        {
            if (Input.GetKeyDown("e"))
            {
                manager.transform.GetComponent<Scene_Manager>().LoadNextScene(nextScene);
            }
        }
    }
}
