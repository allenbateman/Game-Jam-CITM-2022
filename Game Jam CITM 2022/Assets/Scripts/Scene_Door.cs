using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Door : MonoBehaviour
{
    public EScenes nextScene;
    private GameObject player;
    private GameObject manager;
    private int activationDistance = 5;
    private float distanceToPlayer;
    public ELevelList nextLevel = ELevelList.NULL;

    [SerializeField]
    Sprite open, closed;

    SpriteRenderer renderer;

    bool IsOpen = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("Scene_Manager");
        renderer = GetComponent<SpriteRenderer>();


        renderer.sprite = closed;

        IsOpen = false;
    }

    void Update()
    {

        if (IsOpen)
        {
            renderer.sprite = open;
        }
        else
        {
            renderer.sprite = closed;
        }

        distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distanceToPlayer < activationDistance)
        {
            if (Input.GetKeyDown("e"))
            {
                IsOpen = true;
                GameState.scene = nextScene;
                manager.transform.GetComponent<Scene_Manager>().LoadNextScene(nextScene);              
                if(nextLevel != ELevelList.NULL)
                {
                    GameState.level = nextLevel;
                }
            }
        }
    }
}
