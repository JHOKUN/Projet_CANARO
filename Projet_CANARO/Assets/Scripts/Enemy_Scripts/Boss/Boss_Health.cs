using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public CircleCollider2D cc2d;
    public GameObject Boss;
    public int Boss_Health_Value;

    void Start()
    {
        Boss_Health_Value = 5;
    }

    void Update()
    {
        if(Boss_Health_Value <= 0)
        {
            Destroy(Boss);
        }
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if(Collision.gameObject.CompareTag("Hook"))
        {
            Boss_Health_Value -= 1;
        }
    }
}
