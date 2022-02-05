using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;
    Transform target;
    Vector3 newPos;
    float smoothSpeed;

    Vector3 offset;

    void Start()
    {
        cam = GetComponent<Camera>();
        target = FindObjectOfType<Player>().transform;
        smoothSpeed = 0.1f;
        offset = new Vector3(5, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            newPos.x = target.position.x;
            newPos.y = target.position.y;
            newPos.z = -10;
            newPos += offset;

            Vector3 translation = Vector3.Lerp(transform.position, newPos, smoothSpeed);

            transform.position = translation;

        }

    }
}
