using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Door : MonoBehaviour
{
    public Boss_Detection Zone;
    public Animator Door_Animator;

    void Update()
    {
        if(Zone.Door_Open == true)
        {
            Door_Animator.SetBool("Must_Open_Door", true);
        }
    }
}
