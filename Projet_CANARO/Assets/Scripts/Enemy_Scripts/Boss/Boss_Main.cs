using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Main : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public Vector2 Direction;
    public bool Able_To_Attack;
    public bool Able_To_Run;
    public bool Can_Wait_To_Attack;
    public float Speed;
    public float Tick;
    public float Wait_Time_After_Hit;
    public float Wait_Time_To_Attack;

    void Start()
    {
        Able_To_Attack = false;
        Able_To_Run = false;
        Can_Wait_To_Attack = true;
        Speed = 3f;
        Wait_Time_After_Hit = 0.5f;
        Wait_Time_To_Attack = 6f;
    }

    void Update()
    {
        Direction = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        
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
            Attack();
        }
    }

    void Running()
    {
        rb.MovePosition(rb.position + Direction.normalized * Speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        StartCoroutine(Wait_After_Hit());
    }

    IEnumerator Wait_After_Hit()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Able_To_Run = false;
        yield return new WaitForSeconds(Wait_Time_After_Hit);
        Able_To_Run = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
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
        
    }

}