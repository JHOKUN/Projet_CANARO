using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Room_Open : MonoBehaviour
{
    public bool Door_Opening = false;
    public Animator Door_Animator;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Door_Opening = true;
            Door_Animator.SetBool("Must_Open_Door", true);
        }
    }
    
     public void Start()
    {
        Door_Animator.SetBool("Must_Open_Door", false);
    }
}
