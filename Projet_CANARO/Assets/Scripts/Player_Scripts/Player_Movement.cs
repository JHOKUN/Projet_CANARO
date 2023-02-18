using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Vector2 Movement;
    public Rigidbody2D rb;
    public Spawn_Point_Definer Start_Position;
    private bool Is_Dashing = false;
    private bool Able_To_Dash = false;
    public float Move_Speed = 5f;
    public float Dash_Speed = 8f;
    public float Dash_Time = 0.1f;
    public float Dash_Cooldown = 5f;

    private void Running()
    {   
        rb.MovePosition(rb.position + Movement * Move_Speed * Time.fixedDeltaTime);
    }

    private void Dashing()
    {
        if (Mathf.Abs(Movement.x) != Mathf.Abs(Movement.y))
        {
        rb.MovePosition(rb.position + Movement * Dash_Speed * Dash_Time);
        }
    }

    private void Is_Dash_Starting()
    {
        if(Input.GetKey(KeyCode.C))
        {
            Is_Dashing = true;
        }
    }

    void Start()
    {
        transform.position = Start_Position.Spawn_Point_Value;
    }


    void Update()
    {
        // ici sont stockés les inputs
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        Is_Dash_Starting();
    }

    void FixedUpdate()
    {       // ici aura lieu le mouvement
        
        if(Is_Dashing == false)
        {
            Running();
        }
        else
        {
            Dashing();
            Is_Dashing = false;
        }
            
    }
}
