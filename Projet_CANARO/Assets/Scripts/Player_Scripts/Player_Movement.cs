using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Vector2 Movement;
    public Rigidbody2D rb;
    public Spawn_Point_Definer Start_Position;
    private bool Is_Dashing = false;
    private bool Able_To_Dash = true;
    //private bool Able_To_Refill = false;
    public float Max_Player_Stamina;
    public float Current_Player_Stamina;
    public float Move_Speed = 5f;
    public float Dash_Speed = 8f;
    public float Dash_Time = 0.2f;
    public float Dash_Refill_Cooldown = 5f;
    public float Between_Dash_Cooldown = 1f;
    public float Timer;
    public float Tick;
    public static event Action OnPlayerDashed;



    private void Running()
    {   
        rb.MovePosition(rb.position + Movement * Move_Speed * Time.fixedDeltaTime);
    }

    private void Dashing()
    {
        if(Able_To_Dash == true)
            if (Mathf.Abs(Movement.x) != Mathf.Abs(Movement.y))
            {
                rb.MovePosition(rb.position + Movement * Dash_Speed * Dash_Time);
            }
        
    }

    private void Stamina_Refill()
    {
        if(Current_Player_Stamina < Max_Player_Stamina)
        {
            if(Timer == Tick)
            {
                Tick = Timer + Dash_Refill_Cooldown;
                Current_Player_Stamina += 1;
            }
        }




       // if(Current_Player_Stamina < Max_Player_Stamina)
        //{
         //   Able_To_Refill = true;
          //  while(Able_To_Refill == true)
           // {
           //     yield return new WaitForSeconds(Dash_Refill_Cooldown);
           //     Current_Player_Stamina += 1;
          //      Able_To_Refill = false;
          //  }
       // }
    }

    private IEnumerator Dash()
    {
        Is_Dashing = true;
        Dashing();
        Able_To_Dash = false;
        Current_Player_Stamina -= 1;
        yield return new WaitForSeconds(Dash_Time);
        Is_Dashing = false;
        yield return new WaitForSeconds(Between_Dash_Cooldown);
        Able_To_Dash = true;
    }

        void Is_Dash_Starting()
    {
        if(Able_To_Dash == true)
        {
            if(Input.GetKey(KeyCode.C))
            {
               StartCoroutine(Dash());
            }
        }
    }


    void Awake()
    {
        Timer = (int)Time.time;
        Tick = Dash_Refill_Cooldown;
    }


    void Start()
    {
        transform.position = Start_Position.Spawn_Point_Value;
        Current_Player_Stamina = Max_Player_Stamina;
        OnPlayerDashed?.Invoke();
    }


    void Update()
    {
        // ici sont stockés les inputs
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        Is_Dash_Starting();
        Stamina_Refill();
    }

    void FixedUpdate()
    {       // ici aura lieu le mouvement
        
        if(Is_Dashing == false)
        {
            Running();
        }
        else
        {
            Dash();
        }   
    }
}
