using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Hook : MonoBehaviour
{
    public GameObject Hook;
    public GameObject Cursor;
    public Player_Movement Movement_Player;
    public Attack_System Attack;
    public Animator Player_Animator;
    public SpriteRenderer Hook_Sprite;
    public BoxCollider2D Hook_Collider;
    public Rigidbody2D rb;
    public float Shooting_Force = 10f;
    public float Shooting_Cooldown = 0.5f;
    public bool Able_To_Shoot = true;
    public bool Is_Shooting = false;

    IEnumerator Hook_Shooting()
    {
        rb.velocity = new Vector2(0,0);
        Is_Shooting = true;
        Hook_Sprite.enabled = true;
        Hook_Collider.enabled = true;
        Able_To_Shoot = false;

        if(Cursor.transform.localPosition.normalized.x == 0 && Cursor.transform.localPosition.normalized.y == 1)
        {
            Player_Animator.SetBool("Is_Hook_Shooting_Up", true);
        }
        if(Cursor.transform.localPosition.normalized.x == 0 && Cursor.transform.localPosition.normalized.y == -1)
        {
            Player_Animator.SetBool("Is_Hook_Shooting_Down", true);
        }
        if(Cursor.transform.localPosition.normalized.x == 1 && Cursor.transform.localPosition.normalized.y == 0)
        {
            Player_Animator.SetBool("Is_Hook_Shooting_Right", true);
        }
        if(Cursor.transform.localPosition.normalized.x == -1 && Cursor.transform.localPosition.normalized.y == 0)
        {
            Player_Animator.SetBool("Is_Hook_Shooting_Left", true);
        }
        rb.velocity = Hook.transform.localPosition.normalized * Shooting_Force;
        yield return new WaitForSeconds(Shooting_Cooldown);
        rb.velocity = new Vector2(0,0);
        Player_Animator.SetBool("Is_Hook_Shooting_Up", false);
        Player_Animator.SetBool("Is_Hook_Shooting_Left", false);
        Player_Animator.SetBool("Is_Hook_Shooting_Right", false);
        Player_Animator.SetBool("Is_Hook_Shooting_Down", false);
        Is_Shooting = false;
        //Hook_Sprite.enabled = false;
        Hook_Collider.enabled = false;
        
    }
    


    void Update()
    {
        if(Mathf.Abs(Movement_Player.Movement.x) != Mathf.Abs(Movement_Player.Movement.y))
        {
            Hook.transform.localPosition = Movement_Player.Movement;
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
