using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Move_Speed = 5f;
    public Rigidbody2D rb;
    public Spawn_Point_Definer Start_Position;

   Vector2 Movement;

    void Start()
    {

        transform.position = Start_Position.Spawn_Point_Value;

    }


    void Update()
    {
        // ici sont stockés les inputs
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
    
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * Move_Speed * Time.fixedDeltaTime);

        // ici aura lieu le mouvement
        
    }
}
