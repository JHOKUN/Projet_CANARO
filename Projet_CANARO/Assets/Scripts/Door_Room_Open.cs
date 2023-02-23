using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Room_Open : MonoBehaviour
{
    public Animator Door_Animator;
    public Animator Button_Animator;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Button_Animator.SetBool("Is_Pressed", true);
            Door_Animator.SetBool("Must_Open_Door", true);
        }
    }
    
     public void Start()
    {
        Button_Animator.SetBool("Is_Pressed", false);
        Door_Animator.SetBool("Must_Open_Door", false);
    }
}
