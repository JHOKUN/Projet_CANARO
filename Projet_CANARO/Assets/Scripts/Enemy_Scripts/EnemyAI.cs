using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    
    public Player_Movement Movement_Player;
    public Transform Target;
    public Animator Enemy_Animator;
    public Rigidbody2D rb;
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

        Debug.Log(Direction.normalized.x);

        if(Direction.normalized.y < 0 && Mathf.Abs(Direction.normalized.y) > Mathf.Abs(Direction.normalized.x))
        {
            Enemy_Animator.SetBool("Is_Facing_Down", true);
            Enemy_Animator.SetBool("Is_Facing_Left", false);
            Enemy_Animator.SetBool("Is_Facing_Right", false);
        }
        else
        {
            Enemy_Animator.SetBool("Is_Facing_Down", false);
        }
        if(Direction.normalized.y > 0 && Mathf.Abs(Direction.normalized.y) > Mathf.Abs(Direction.normalized.x))
        {
            Enemy_Animator.SetBool("Is_Facing_Up", true);
            Enemy_Animator.SetBool("Is_Facing_Left", false);
            Enemy_Animator.SetBool("Is_Facing_Right", false);
        }
        else
        {
            Enemy_Animator.SetBool("Is_Facing_Up", false);
        }
        if(Direction.normalized.x < 0 && Mathf.Abs(Direction.normalized.y) < Mathf.Abs(Direction.normalized.x))
        {
            Enemy_Animator.SetBool("Is_Facing_Left", true);
            Enemy_Animator.SetBool("Is_Facing_Up", false);
            Enemy_Animator.SetBool("Is_Facing_Down", false);
        }
        else
        {
            Enemy_Animator.SetBool("Is_Facing_Left", false);
        }
        if(Direction.normalized.x > 0 && Mathf.Abs(Direction.normalized.y) < Mathf.Abs(Direction.normalized.x))
        {
            Enemy_Animator.SetBool("Is_Facing_Right", true);
            Enemy_Animator.SetBool("Is_Facing_Up", false);
            Enemy_Animator.SetBool("Is_Facing_Down", false);
        }
        else
        {
            Enemy_Animator.SetBool("Is_Facing_Right", false);
        }
    }
}
