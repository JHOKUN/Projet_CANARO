using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{   
    public GameObject Hook_Object;
    public GameObject Cursor;
    public Attack_System Attack;
    public Shooting_Hook Hook;
    public Hook_Script Script_Hook;
    public Hookable_Object_Script Drag_Script;
    private BoxCollider2D Player_Collider;
    public Vector2 Movement;
    public Vector2 New_Direction;
    public Transform Target = null;
    public Rigidbody2D rb;
    public TrailRenderer Dash_Trail;
    public Spawn_Point_Definer Start_Position;
    public Animator Player_Animator;
    public RaycastHit2D Dash_Raycast_Heights;
    public RaycastHit2D Dash_Raycast_Edges_Dash;
    public RaycastHit2D Dash_Raycast_Holes;
    [SerializeField] private LayerMask Dash_Layer_Mask_Heights;
    [SerializeField] private LayerMask Dash_Layer_Mask_Edges_Dash;
    [SerializeField] private LayerMask Dash_Layer_Mask_Holes;
    public bool Player_Must_Drag = false;
    public bool Must_Respawn = false;
    public bool Is_Dashing = false;
    public bool Able_To_Dash = true;
    public bool Able_To_Refill = false;
    public bool Dashed = false;
    public float Max_Player_Stamina;
    public float Current_Player_Stamina;
    public float Move_Speed = 5f;
    public float Dash_Speed = 8f;
    public float Dash_Time = 0.2f;
    public float Dash_Refill_Cooldown = 5f;
    public float Between_Dash_Cooldown = 1f;
    public float Tick;
    public static event Action OnPlayerDashed;



    private void Running()
    {   
        rb.MovePosition(rb.position + Movement * Move_Speed * Time.fixedDeltaTime);
    }

    private void Dashing()
    {
        if(Able_To_Dash == true)
        {   
            Dash_Raycast_Heights = Physics2D.Raycast(transform.position, Movement, 0.1f, Dash_Layer_Mask_Heights);
            Dash_Raycast_Edges_Dash = Physics2D.Raycast(transform.position, Movement, 2f, Dash_Layer_Mask_Edges_Dash);
            Dash_Raycast_Holes = Physics2D.Raycast(transform.position, Movement, 2f, Dash_Layer_Mask_Holes);
            rb.velocity = Movement * Dash_Speed;
            Dash_Trail.emitting = true;
            Dashed = true;
            if (Dash_Raycast_Heights.collider != null && Dash_Raycast_Edges_Dash.collider != null || Dash_Raycast_Holes.collider != null)
            {
                Player_Collider.enabled = false;
            }
        }
        
    }

    private void Stamina_Refill()
    {
        if(Current_Player_Stamina < Max_Player_Stamina)
        {
            if(Time.time > Tick)                
            {
                Tick = Time.time + Dash_Refill_Cooldown;
                Current_Player_Stamina += 1;
            }
        }
    }
    

    private IEnumerator Dash()
    {
        if(Mathf.Abs(Movement.x) != Mathf.Abs(Movement.y))
        {
            if(Current_Player_Stamina > 0 && Attack.Is_Attacking == false && Hook.Is_Shooting == false)
            {
                Is_Dashing = true;
                Attack.Able_To_Attack = false;
                Dashing();
                if(Dashed == true)
                {
                    Current_Player_Stamina -= 1;
                    Debug.Log("-1 Stamina");
                }
                Dashed = false;
                Able_To_Dash = false;
                yield return new WaitForSeconds(Dash_Time);
                Player_Collider.enabled = true;
                Dash_Trail.emitting = false;
                Is_Dashing = false;
                Attack.Able_To_Attack = true;
                yield return new WaitForSeconds(Between_Dash_Cooldown);
                Able_To_Dash = true;
            }
        }
    }

    void Is_Dash_Starting()
    {
        if(Able_To_Dash == true && Attack.Is_Attacking == false && Hook.Is_Shooting == false)
        {
            if(Input.GetKey(KeyCode.Space))
            {
               StartCoroutine(Dash());
            }
        }
    }
    public void Set_Target(Transform New_Target)
    {
        Target = New_Target;
    }
    public void Hook_Drag()
    {
        New_Direction = new Vector2(Target.position.x, Target.position.y);
        transform.position = Vector2.MoveTowards(transform.position, New_Direction, 10f * Time.deltaTime);
        if(Vector2.Distance(Target.position, transform.position) < 0.1f )
        {
            Player_Must_Drag = false;
        }
    }

    void Direction_Aiming()
    {
        if(Mathf.Abs(Movement.x) != Mathf.Abs(Movement.y))
        {
            Cursor.transform.localPosition = Movement;
        }
    }

    void Awake()
    {
        Tick = Dash_Refill_Cooldown;
    }


    void Start()
    {
        Player_Collider = gameObject.GetComponent<BoxCollider2D>();
        transform.position = Start_Position.Spawn_Point_Value;
        Current_Player_Stamina = Max_Player_Stamina;
        OnPlayerDashed?.Invoke();
        Player_Animator.SetBool("Is_Running_Down", false);
    }


    void Update()
    {
        if(Must_Respawn == true)
        {
            transform.position = Start_Position.Spawn_Point_Value;
            Must_Respawn = false;
        }
        
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        Direction_Aiming();
        Is_Dash_Starting();
        Stamina_Refill();
    }

    void FixedUpdate()
    {
        if(Movement.y == -1)
        {
            Player_Animator.SetBool("Is_Running_Down", true);
            Player_Animator.SetBool("Is_Facing_Forward", false);
        }
        else
        {
            Player_Animator.SetBool("Is_Running_Down", false);
            Player_Animator.SetBool("Is_Facing_Forward", true);
        }
        if(Movement.y == 1)
        {
            Player_Animator.SetBool("Is_Facing_Backward", false);
            Player_Animator.SetBool("Is_Running_Up", true);
        }
        else
        {
            Player_Animator.SetBool("Is_Running_Up", false);
            Player_Animator.SetBool("Is_Facing_Backward", true);
        }
        if(Movement.x == -1)
        {
            Player_Animator.SetBool("Is_Running_Side", true);
            Player_Animator.SetBool("Is_Facing_Side", false);
        }
        else
        {
            Player_Animator.SetBool("Is_Running_Side", false);
            Player_Animator.SetBool("Is_Facing_Side", true);
        }
        if(Movement.x == 1)
        {
            Player_Animator.SetBool("Is_Running_Right", true);
            Player_Animator.SetBool("Is_Facing_Right", false);
        }
        else
        {
            Player_Animator.SetBool("Is_Running_Right", false);
            Player_Animator.SetBool("Is_Facing_Right", true);
        }

        if(Player_Must_Drag == true)
        {
            Hook_Drag();
        }
        if(Is_Dashing == false && Attack.Is_Attacking == false && Hook.Is_Shooting == false)
        {
            Running();
        }
    }
}
