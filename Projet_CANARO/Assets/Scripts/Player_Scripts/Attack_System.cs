using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_System : MonoBehaviour
{
    public GameObject Cursor;
    public Player_Movement Movement_Player;
    public Shooting_Hook Hook;
    public CapsuleCollider2D Up_Area;
    public CapsuleCollider2D Left_Area;
    public CapsuleCollider2D Right_Area;
    public CapsuleCollider2D Down_Area;
    public Animator Player_Animator;
    public bool Able_To_Attack;
    public bool Is_Attacking;
    public float Attack_Cooldown = 0.2f;


    private IEnumerator Attack()
    {
        Is_Attacking = true;
        Able_To_Attack = false;
        if(Cursor.transform.localPosition.normalized.x == 0 && Cursor.transform.localPosition.normalized.y == 1)
        {
            Player_Animator.SetTrigger("Attack_Up_Trigger");
            Player_Animator.SetBool("Is_Running_Up", false);
            Up_Area.enabled = true;
        }

        if(Cursor.transform.localPosition.normalized.x == 0 && Cursor.transform.localPosition.normalized.y == -1)
        {
            Player_Animator.SetTrigger("Attack_Down_Trigger");
            Player_Animator.SetBool("Is_Running_Down", false);
            Down_Area.enabled = true;
        }

        if(Cursor.transform.localPosition.normalized.x == 1 && Cursor.transform.localPosition.normalized.y == 0)
        {
            Player_Animator.SetTrigger("Attack_Right_Trigger");
            Player_Animator.SetBool("Is_Running_Right", false);
            Right_Area.enabled = true;
        }

        if(Cursor.transform.localPosition.normalized.x == -1 && Cursor.transform.localPosition.normalized.y == 0)
        {
            Player_Animator.SetTrigger("Attack_Left_Trigger");
            Player_Animator.SetBool("Is_Running_Side", false);
            Left_Area.enabled = true;
        }

        Movement_Player.Able_To_Dash = false;
        Is_Attacking = false;
        Movement_Player.Able_To_Dash = true;
        yield return new WaitForSeconds(Attack_Cooldown);
        Up_Area.enabled = false;
        Down_Area.enabled = false;
        Right_Area.enabled = false;
        Left_Area.enabled = false;
        Able_To_Attack = true;
    }




    void Start()
    {
        Up_Area.enabled = false;
        Down_Area.enabled = false;
        Right_Area.enabled = false;
        Left_Area.enabled = false;
        Able_To_Attack = true;
    }

    void Update()
    {
        if(Able_To_Attack == true && Movement_Player.Is_Dashing == false && Hook.Is_Shooting == false)
        {
            Movement_Player.rb.velocity = new Vector2(0,0);
            if(Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(Attack());
            }
        }
    }
}
