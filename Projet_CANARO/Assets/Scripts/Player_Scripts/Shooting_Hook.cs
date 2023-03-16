using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Hook : MonoBehaviour
{
    public GameObject Hook;
    public GameObject Cursor;
    public Transform Shoot_Origin_Down;
    public Transform Shoot_Origin_Right;
    public Transform Shoot_Origin_Left;
    public Transform Shoot_Origin_Up;
    public Hook_Script Script_Hook;
    public Hookable_Object_Script Target_Script;
    public Player_Movement Movement_Player;
    public Attack_System Attack;
    public Animator Player_Animator;
    public SpriteRenderer Hook_Sprite;
    public Rigidbody2D rb_Hook;
    public BoxCollider2D Hook_Collider;
    public Vector2 Aim_Direction;
    public float Shooting_Force = 10f;
    public float Shooting_Cooldown = 0.5f;
    public float Shoot_Duration = 0.7f;
    public bool Player_Being_Drag = false;
    public bool Able_To_Shoot = true;
    public bool Is_Shooting = false;

    IEnumerator Hook_Shooting()
    {
        Is_Shooting = true;
        Able_To_Shoot = false;
        if(Cursor.transform.localPosition.normalized.x == 0 && Cursor.transform.localPosition.normalized.y == 1)
        {
            Instantiate(Hook, Shoot_Origin_Up.position, Shoot_Origin_Up.rotation);
            Player_Animator.SetBool("Is_Hook_Shooting_Up", true);
        }
        if(Cursor.transform.localPosition.normalized.x == 0 && Cursor.transform.localPosition.normalized.y == -1)
        {
            Instantiate(Hook, Shoot_Origin_Down.position, Shoot_Origin_Down.rotation);
            Player_Animator.SetBool("Is_Hook_Shooting_Down", true);
        }
        if(Cursor.transform.localPosition.normalized.x == 1 && Cursor.transform.localPosition.normalized.y == 0)
        {
            Instantiate(Hook, Shoot_Origin_Right.position, Shoot_Origin_Right.rotation);
            Player_Animator.SetBool("Is_Hook_Shooting_Right", true);
        }
        if(Cursor.transform.localPosition.normalized.x == -1 && Cursor.transform.localPosition.normalized.y == 0)
        {
            Instantiate(Hook, Shoot_Origin_Left.position, Shoot_Origin_Left.rotation);
            Player_Animator.SetBool("Is_Hook_Shooting_Left", true);
        }
        yield return new WaitForSeconds(Shoot_Duration);
        if(Player_Being_Drag == false)
        {
            Script_Hook.Exists = false;
        }
        if(Script_Hook.Exists == false)
        {
            Player_Animator.SetBool("Is_Hook_Shooting_Up", false);
            Player_Animator.SetBool("Is_Hook_Shooting_Left", false);
            Player_Animator.SetBool("Is_Hook_Shooting_Right", false);
            Player_Animator.SetBool("Is_Hook_Shooting_Down", false);  
        }
        Is_Shooting = false;
    }
    void Update()
    {
        if(Mathf.Abs(Movement_Player.Movement.x) != Mathf.Abs(Movement_Player.Movement.y) || Player_Animator.GetBool("Is_Facing_Backward") == true)
        {
            if(Able_To_Shoot == true && Movement_Player.Is_Dashing == false && Attack.Is_Attacking == false)
            {
                Movement_Player.rb.velocity = new Vector2(0,0);
                if(Input.GetKeyDown(KeyCode.N))
                {
                    Movement_Player.rb.velocity = new Vector2(0,0);
                    StartCoroutine(Hook_Shooting());
                    
                    Able_To_Shoot = true;
                }
            }
        }
        
    }
}