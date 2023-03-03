using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Player_Movement Movement_Player;
    public Rigidbody2D rb;
    public Transform Target;
    public Vector2 Direction;
    public bool Able_To_Run = true;
    public float Maximum_Distance;
    public float Minimum_Distance;
    public float Speed;
    public float Waiting_Time;

    void Running()
    {
        if (Vector2.Distance(transform.position, Target.position) > Minimum_Distance && Vector2.Distance(transform.position, Target.position) < Maximum_Distance)
        {
            rb.MovePosition(rb.position + Direction.normalized * Speed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            StartCoroutine(Wait_After_Hit());
        }
    }

    IEnumerator Wait_After_Hit()
    {
        Able_To_Run = false;
        rb.bodyType = RigidbodyType2D.Static;
        // lancer animation attaque
        yield return new WaitForSeconds(Waiting_Time);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Able_To_Run = true;
    }


    void Start()
    {
        Waiting_Time = 1.5f;
    }

    private void Update()
    {
        Direction = new Vector2(Target.position.x - transform.position.x, Target.position.y - transform.position.y);
        
        if (Able_To_Run == true)
        {
            Running();
        }

        
    }
}
