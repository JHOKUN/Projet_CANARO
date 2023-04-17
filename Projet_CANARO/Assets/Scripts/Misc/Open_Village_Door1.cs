using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Village_Door : MonoBehaviour
{
    public BoxCollider2D Collide;
    public Animator Door_Animator;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.CompareTag("Player"))
        {
            Door_Animator.SetTrigger("Open");
        }
    }
}
