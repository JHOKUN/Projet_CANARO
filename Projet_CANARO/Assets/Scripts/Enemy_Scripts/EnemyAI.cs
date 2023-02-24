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

    void Running()
    {
        if (Vector2.Distance(transform.position, Target.position) > Minimum_Distance && Vector2.Distance(transform.position, Target.position) < Maximum_Distance)
        {
            rb.MovePosition(rb.position + Direction.normalized * Speed * Time.fixedDeltaTime);
        }
    }

    //void OnCollisionEnter(Collider collision)
    //{

    //}

    //IEnumerator Is_Colliding()
    //{
    //    if (Collision)
    //}

    private void Update()
    {
        Direction = new Vector2(Target.position.x - transform.position.x, Target.position.y - transform.position.y);

        //StartCoroutine(Is_Colliding());
        
        if (Able_To_Run == true)
        {
            Running();
        }

        
    }
}
