using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D Collider;
    public float Shooting_Force = 10f;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hookable"))
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    void Start()
    {
        rb.velocity = transform.right * Shooting_Force;    
    }
}
