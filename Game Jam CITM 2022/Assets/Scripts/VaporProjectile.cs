using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    BoxCollider2D collider;
    Animator anim;
    AnimatorClipInfo[] animationClip;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
        anim = GetComponent<Animator>();
        animationClip = anim.GetCurrentAnimatorClipInfo(0);
    }

    void SetCollider()
    {
        collider.enabled = true;
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
