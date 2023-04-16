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

                Capsule.offset = new Vector2(0.06188626f, 0.02510474f);
                Capsule.size = new Vector2(0.7732959f, 1.411959f);
                Capsule.direction = CapsuleDirection2D.Vertical;
            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Right", false);
                ba.SetBool("Is_Attacking_Right", true);
                ba.SetBool("Is_Stunned_Right", false);

                Capsule.offset = new Vector2(0.08794212f, 0.02510474f);
                Capsule.size = new Vector2(0.8254077f, 1.411959f);
                Capsule.direction = CapsuleDirection2D.Vertical;
            }

            if(bm.Is_Stunned)
            {
                ba.SetBool("Is_Facing_Right", false);
                ba.SetBool("Is_Attacking_Right", false);
                ba.SetBool("Is_Stunned_Right", true);

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

                Capsule.offset = new Vector2(-0.03639656f, 0.02510474f);
                Capsule.size = new Vector2(0.7605355f, 1.411959f);
                Capsule.direction = CapsuleDirection2D.Vertical;
            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Left", false);
                ba.SetBool("Is_Attacking_Left", true);
                ba.SetBool("Is_Stunned_Left", false);

                Capsule.offset = new Vector2(-0.07843431f, 0.02510474f);
                Capsule.size = new Vector2(0.844611f, 1.411959f);
                Capsule.direction = CapsuleDirection2D.Vertical;

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

                Capsule.offset = new Vector2(-0.0006367338f, 0.02389092f);
                Capsule.size = new Vector2(1.563937f, 1.244692f);
                Capsule.direction = CapsuleDirection2D.Horizontal;

            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Up", false);
                ba.SetBool("Is_Attacking_Up", true);
                ba.SetBool("Is_Stunned_Up", false);

                Capsule.offset = new Vector2(-0.0007249049f, -0.05306011f);
                Capsule.size = new Vector2(1.605619f, 1.025286f);
                Capsule.direction = CapsuleDirection2D.Horizontal;

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

                Capsule.offset = new Vector2(-0.0007249049f, -0.05306011f);
                Capsule.size = new Vector2(1.605619f, 1.025286f);
                Capsule.direction = CapsuleDirection2D.Horizontal;
            }

            if(bm.Able_To_Attack)
            {
                ba.SetBool("Is_Facing_Down", false);
                ba.SetBool("Is_Attacking_Down", true);
                ba.SetBool("Is_Stunned_Down", false);

                Capsule.offset = new Vector2(-0.000636727f, 0.08107939f);
                Capsule.size = new Vector2(1.563937f, 1.178475f);
                Capsule.direction = CapsuleDirection2D.Horizontal;
            }

            if(bm.Is_Stunned)
            {
                ba.SetBool("Is_Facing_Down", false);
                ba.SetBool("Is_Attacking_Down", false);
                ba.SetBool("Is_Stunned_Down", true);
            }
        }
        
    }
}
