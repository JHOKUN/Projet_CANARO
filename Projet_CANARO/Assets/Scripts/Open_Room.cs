using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Room : MonoBehaviour
{
    public Animator Door_Animator;
    public Transform Target;
    

    public void Start()
    {
        Door_Animator.SetBool("Must_Open_Door", false);
    }


    public void Update()
    {
        //if(Door_Room_Open.Door_Opening == true && Vector2.Distance(transform.position, Target.position) < 5)
        {
          //  Door_Animator.SetBool("Must_Open_Door", true);
        }
    }
}
