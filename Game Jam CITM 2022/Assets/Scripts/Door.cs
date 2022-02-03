using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField]
    Vector2 originalPos;
    private float offsetDistance = 10;
    float speed = 0.1f;
    private bool reseting = false;
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive && gameObject.transform.position.y < originalPos.y + offsetDistance)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed);
        }
        if(!isActive && gameObject.transform.position.y > originalPos.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed);
        }
        if(reseting && gameObject.transform.position.y > originalPos.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed);
            if ((Vector2)gameObject.transform.position == originalPos) reseting = false;
        }
    }

    public void UnLock()
    {
        isActive = !isActive;
    }
    public void ResetPosition()
    {
        //gameObject.transform.position = originalPos;
        reseting = true;
        isActive = false;
    }
}
