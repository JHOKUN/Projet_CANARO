using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Main : MonoBehaviour
{
    public Is_In_Boss_Room Is_In_Boss_Room;
    public Rigidbody2D rb;
    public Vector2 Direction;
    public bool Able_To_Run;
    public float Speed;
    public float Knockback;

    void Start()
    {
        Able_To_Run = false;
        Speed = 3f;
        Knockback = 10f;
        
    }

    void Update()
    {
        if (Is_In_Boss_Room.Is_In_Boss_Room_Bool)
        {
            Able_To_Run = true;
        }
        
        if (Able_To_Run)
        {
            Running();
        }

        Direction = new Vector2(Is_In_Boss_Room.Player.transform.position.x - transform.position.x, Is_In_Boss_Room.Player.transform.position.y - transform.position.y);
    }

    void Running()
    {
        rb.MovePosition(rb.position + Direction.normalized * Speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        Is_In_Boss_Room.Player_Rigidbody.AddForce(Direction.normalized * 50, ForceMode2D.Impulse);
        Is_In_Boss_Room.Player.GetComponent<Rigidbody2D>().MovePosition(Is_In_Boss_Room.Player.GetComponent<Rigidbody2D>().position + Direction.normalized * Knockback * Time.fixedDeltaTime);
    }

}