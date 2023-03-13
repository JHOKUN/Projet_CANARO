using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Script : MonoBehaviour
{
    public GameObject Hook;
    public Vector2 Aim_Direction;
    public Rigidbody2D rb;
    public float Shooting_Force = 10f;

    void Start()
    {
        rb.velocity = transform.right * Shooting_Force;    
    }
}
