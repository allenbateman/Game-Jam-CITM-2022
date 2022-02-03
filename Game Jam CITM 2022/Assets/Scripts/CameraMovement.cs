using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera cam;
    Transform target;
    Vector3 newPos;
   [SerializeField]
    float smoothSpeed;
    void Start()
    {
        cam = GetComponent<Camera>();
        target = FindObjectOfType<Player>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            newPos.x = target.position.x;
            newPos.y = 0;
            newPos.z = -10;
            Vector3 translation = Vector3.Lerp(transform.position ,newPos,smoothSpeed);

            transform.position = translation;

        }

    }
}
