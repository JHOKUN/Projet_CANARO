using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Test_Movement : MonoBehaviour
{
    public float Enemy_Speed;
    public Rigidbody2D rb;
    public Vector2 Direction;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            
        }


    }

    void FixedUpdate()
    {
        transform.Translate(Direction * Enemy_Speed * Time.deltaTime);
    }
}
