using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public GameObject Enemy;
    public float Waiting_Time;
    public int Damage_Amount;
    public int Enemy_Health_Value = 5;


    void Start()
    {
        Waiting_Time = 1.5f;
        Damage_Amount = 1;
    }
    
    void Enemy_Taking_Damage()
    {
        Enemy_Health_Value -= Damage_Amount;
        StartCoroutine(Wait_After_Hit());
    }

    IEnumerator Wait_After_Hit()
    {
        Enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(Waiting_Time);
        Enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if(Collision.gameObject.CompareTag("Dagger"))
        {
            Enemy_Taking_Damage();
        }
    }

    void Update()
    {
        if(Enemy_Health_Value <= 0)
        {
            Destroy(Enemy);
        }
    }
}
