using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Door : MonoBehaviour
{
    public Enemy_Detection_Door Zone;
    public Animator Door_Animator;

    void Update()
    {
        if(Zone.Doors_Open == true)
        {
            Door_Animator.SetBool("Must_Open_Door", true);
        }
    }
}
