using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_System : MonoBehaviour
{
    public Player_Movement Movement_Player;
    public CapsuleCollider2D Up_Area;
    public CapsuleCollider2D Left_Area;
    public CapsuleCollider2D Right_Area;
    public CapsuleCollider2D Down_Area;
    public Animator Player_Animator;
    public bool Able_To_Attack;
    public bool Is_Attacking;
    public float Attack_Cooldown = 0.5f;


    private IEnumerator Attack_Up()
    {
        Is_Attacking = true;
        Up_Area.enabled = true;
        Able_To_Attack = false;
        Player_Animator.SetTrigger("Attack_Up_Trigger");
        Player_Animator.SetBool("Is_Running_Up", false);
        Movement_Player.Able_To_Dash = false;
        yield return new WaitForSeconds(Attack_Cooldown);
        Up_Area.enabled = false;
        Is_Attacking = false;
        Movement_Player.Able_To_Dash = true;
        Able_To_Attack = true;
    }

    void Start()
    {
        Able_To_Attack = true;
    }

    void Update()
    {
        if(Able_To_Attack == true && Movement_Player.Is_Dashing == false)
        {
            if(Player_Animator.GetBool("Is_Running_Up") == true || Player_Animator.GetBool("Is_Facing_Backward") == true)
            {
                if(Input.GetKeyDown(KeyCode.V))
                {
                    StartCoroutine(Attack_Up());
                }
            }
        }


    }
}
