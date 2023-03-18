using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D Collider;
    public TrailRenderer Rope;
    public bool Exists;
    public bool Hookable_Touched = false;
    public float Shooting_Force = 10f;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hookable"))
        {
            Hookable_Touched = true;
            rb.velocity = new Vector2(0,0);
            Collider.isTrigger = true;
            Rope.time = 0.3879f;
        }
        else if(collision.gameObject.CompareTag("Unhookable"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb.velocity = transform.right * Shooting_Force;
        Exists = true;
        Hookable_Touched = false;
        Rope.emitting = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}