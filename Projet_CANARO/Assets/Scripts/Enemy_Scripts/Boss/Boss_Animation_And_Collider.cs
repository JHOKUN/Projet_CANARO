using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Animation_And_Collider : MonoBehaviour
{
    public Animator ba;
    public Boss_Main bm;
    public Cursor_Position cp;
    public CapsuleCollider2D Capsule;

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

            ba.SetBool("Is_Stunned_Left", false);
            ba.SetBool("Is_Stunned_Up", false);
            ba.SetBool("Is_Stunned_Down", false);

            if(bm.Able_To_Run)
            {
                ba.SetBool("Is_Facing_Right", true);
                ba.SetBool("Is_Attacking_Right", false);
                ba.SetBool("Is_Stunned_Right", false);

                Capsule.offset = new Vector2(0.0300488f, 0.01829199f);
                Capsule.size = new Vector2(0.3768222f, 0.7006721f);
                Capsule.direction = CapsuleDirection2D.Vertical;
            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Right", false);
                ba.SetBool("Is_Attacking_Right", true);
                ba.SetBool("Is_Stunned_Right", false);

                Capsule.offset = new Vector2(0.03500583f, 0.01366544f);
                Capsule.size = new Vector2(0.4157422f, 0.7074328f);
                Capsule.direction = CapsuleDirection2D.Vertical;
            }

            if(bm.Is_Stunned)
            {
                ba.SetBool("Is_Facing_Right", false);
                ba.SetBool("Is_Attacking_Right", false);
                ba.SetBool("Is_Stunned_Right", true);

                Capsule.offset = new Vector2(0.03500583f, 0.01366544f);
                Capsule.size = new Vector2(0.4157422f, 0.7074328f);
                Capsule.direction = CapsuleDirection2D.Vertical;
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

            ba.SetBool("Is_Stunned_Right", false);
            ba.SetBool("Is_Stunned_Up", false);
            ba.SetBool("Is_Stunned_Down", false);
            
            if(bm.Able_To_Run)
            {
                ba.SetBool("Is_Facing_Left", true);
                ba.SetBool("Is_Attacking_Left", false);
                ba.SetBool("Is_Stunned_Left", false);

                //Capsule.offset = new Vector2(f, f);
                //Capsule.size = new Vector2(f, f);
                //Capsule.direction = 0;
            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Left", false);
                ba.SetBool("Is_Attacking_Left", true);
                ba.SetBool("Is_Stunned_Left", false);

            }

            if(bm.Is_Stunned)
            {
                ba.SetBool("Is_Facing_Left", false);
                ba.SetBool("Is_Attacking_Left", false);
                ba.SetBool("Is_Stunned_Left", true);

            }
        }
        else if(cp.Cursor_Direction == "Up")
        {
            ba.SetBool("Is_Facing_Right", false);
            ba.SetBool("Is_Facing_Left", false);
            ba.SetBool("Is_Facing_Down", false);

            ba.SetBool("Is_Attacking_Right", false);
            ba.SetBool("Is_Attacking_Left", false);
            ba.SetBool("Is_Attacking_Down", false);

            ba.SetBool("Is_Stunned_Right", false);
            ba.SetBool("Is_Stunned_Left", false);
            ba.SetBool("Is_Stunned_Down", false);

            if(bm.Able_To_Run)
            {
                ba.SetBool("Is_Facing_Up", true);
                ba.SetBool("Is_Attacking_Up", false);
                ba.SetBool("Is_Stunned_Up", false);

            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Up", false);
                ba.SetBool("Is_Attacking_Up", true);
                ba.SetBool("Is_Stunned_Up", false);

            }

            if(bm.Is_Stunned)
            {
                ba.SetBool("Is_Facing_Up", false);
                ba.SetBool("Is_Attacking_Up", false);
                ba.SetBool("Is_Stunned_Up", true);

            }
        }
        else if(cp.Cursor_Direction == "Down")
        {
            ba.SetBool("Is_Facing_Right", false);
            ba.SetBool("Is_Facing_Left", false);
            ba.SetBool("Is_Facing_Up", false);

            ba.SetBool("Is_Attacking_Right", false);
            ba.SetBool("Is_Attacking_Left", false);
            ba.SetBool("Is_Attacking_Up", false);

            ba.SetBool("Is_Stunned_Right", false);
            ba.SetBool("Is_Stunned_Left", false);
            ba.SetBool("Is_Stunned_Up", false);

            if(bm.Able_To_Run)
            {
                ba.SetBool("Is_Facing_Down", true);
                ba.SetBool("Is_Attacking_Down", false);
                ba.SetBool("Is_Stunned_Down", false);

                Capsule.offset = new Vector2(0.002486747f, -0.01616034f);
                Capsule.size = new Vector2(0.7695759f, 0.5576625f);
                Capsule.direction = CapsuleDirection2D.Horizontal;
            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Down", false);
                ba.SetBool("Is_Attacking_Down", true);
                ba.SetBool("Is_Stunned_Down", false);

                Capsule.offset = new Vector2(0.002486753f, 0.02690534f);
                Capsule.size = new Vector2(0.7695761f, 0.3957389f);
                Capsule.direction = CapsuleDirection2D.Horizontal;
            }

            if(bm.Is_Stunned)
            {
                ba.SetBool("Is_Facing_Down", false);
                ba.SetBool("Is_Attacking_Down", false);
                ba.SetBool("Is_Stunned_Down", true);

                Capsule.offset = new Vector2(0.00248675f, 0.004510988f);
                Capsule.size = new Vector2(0.7695762f, 0.3509516f);
                Capsule.direction = CapsuleDirection2D.Horizontal;
            }
        }
        
    }
}
