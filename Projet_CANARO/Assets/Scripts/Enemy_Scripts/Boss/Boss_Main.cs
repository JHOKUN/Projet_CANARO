using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Main : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public Vector2 Direction_To_Attack;
    public Vector2 Direction_To_Run;
    public bool Able_To_Attack;
    public bool Able_To_Run;
    public bool Can_Wait_To_Attack;
    public bool Is_Attacking;
    public bool Is_Stunned;
    public float Attack_Speed;
    public float Run_Speed;
    public float Stunned_Time;
    public float Tick;
    public float Wait_Time_After_Hit;
    public float Wait_Time_After_Hooked;
    public float Wait_Time_To_Attack;

    void Start()
    {
        Able_To_Attack = false;
        Able_To_Run = false;
        Can_Wait_To_Attack = false;
        Is_Attacking = false;
        Is_Stunned = false;
        Attack_Speed = 10f;
        Run_Speed = 3f;
        Stunned_Time = 4.5f;
        Wait_Time_After_Hit = 0.5f;
        Wait_Time_After_Hooked = 2;
        Wait_Time_To_Attack = 6f;
    }

    void Update()
    {
        Direction_To_Run = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        
        
        if(Is_Stunned)
        {
            Tick = Time.time + Wait_Time_To_Attack;
        }
        else if(Is_Stunned == false)
        {
            if (Able_To_Run)
            {
                Running();
            }

            if (Can_Wait_To_Attack)
            {
                Wait_To_Attack();
            }

            if (Able_To_Attack)
            {
                Able_To_Run = false;
                Attack();
            }
        }
    }

    void Running()
    {
        rb.MovePosition(rb.position + Direction_To_Run.normalized * Run_Speed * Time.fixedDeltaTime);
    }

    void Wait_To_Attack()
    {  
        if (Time.time > Tick)
        {
            Tick = Time.time + Wait_Time_To_Attack;
            Able_To_Attack = true;
            Can_Wait_To_Attack = false;
        }
    }

    void Attack()
    {
        Is_Attacking = true;
        rb.MovePosition(rb.position + Direction_To_Attack.normalized * Attack_Speed * Time.fixedDeltaTime);
    }

    IEnumerator Wait_After_Hit(float Time)
    {
        rb.bodyType = RigidbodyType2D.Static;
        Able_To_Run = true;
        Able_To_Attack = false;
        Is_Attacking = false;
        yield return new WaitForSeconds(Time);
        Can_Wait_To_Attack = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator Stun()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Able_To_Run = true;
        yield return new WaitForSeconds(Stunned_Time);
        Is_Attacking = false;
        Can_Wait_To_Attack = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        Is_Stunned = false;
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if(Is_Attacking == true && Collision.gameObject.CompareTag("Unhookable"))
        {
            Is_Stunned = true;
            Able_To_Attack = false;
            StartCoroutine(Stun());
        }

        if(Collision.gameObject.CompareTag("Player") && Is_Stunned == false)
        {
            Able_To_Attack = false;
            Is_Attacking = false;
            StartCoroutine(Wait_After_Hit(Wait_Time_After_Hit));
            Can_Wait_To_Attack = true;
        }

        if( Collision.gameObject.CompareTag("Hook"))
        {
            StartCoroutine(Wait_After_Hit(Wait_Time_After_Hooked));
        }
    }
}