using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Animation : MonoBehaviour
{
    public Animator ba;
    public Boss_Main bm;
    public Cursor_Position cp;

    void Update()
    {
        if(cp.Cursor_Direction == "Right")
        {
            ba.SetBool("Is_Facing_Left", false);
            ba.SetBool("Is_Facing_Up", false);
            ba.SetBool("Is_Facing_Down", false);

            ba.SetBool("Is_Attacking_Left", false);
            ba.SetBool("Is_Attacking_Up", false);
            ba.SetBool("Is_Attacking_Down", false);

            if(bm.Able_To_Run)
            {
                ba.SetBool("Is_Facing_Right", true);
            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Attacking_Right", true);
            }
        }
        else if(cp.Cursor_Direction == "Left")
        {
            ba.SetBool("Is_Facing_Right", false);
            ba.SetBool("Is_Facing_Up", false);
            ba.SetBool("Is_Facing_Down", false);

            ba.SetBool("Is_Attacking_Right", false);
            ba.SetBool("Is_Attacking_Up", false);
            ba.SetBool("Is_Attacking_Down", false);
            
            if(bm.Able_To_Run)
            {
                
                ba.SetBool("Is_Facing_Left", true);
            }
        }
        else if(cp.Cursor_Direction == "Up")
        {
            ba.SetBool("Is_Facing_Right", false);
            ba.SetBool("Is_Facing_Left", false);
            ba.SetBool("Is_Facing_Down", false);

            if(bm.Able_To_Run)
            {
                ba.SetBool("Is_Facing_Up", true);
            }
        }
        else if(cp.Cursor_Direction == "Down")
        {
            ba.SetBool("Is_Facing_Right", false);
            ba.SetBool("Is_Facing_Left", false);
            ba.SetBool("Is_Facing_Up", false);

            if(bm.Able_To_Run)
            {
                ba.SetBool("Is_Facing_Down", true);
            }
        }
        
    }
}
