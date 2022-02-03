using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawGizmos : MonoBehaviour
{
    [SerializeField]
    Color color = new Color (1,0,0,1);
    [SerializeField]
    float size = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, size);

    }
}
