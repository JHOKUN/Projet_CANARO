using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public GameObject Enemy;
    public EnemyAI AI;
    public int Enemy_Health_Value = 5;


    public void Enemy_Taking_Damage(int Damage_Amount)
    {
        Enemy_Health_Value -= Damage_Amount;
        StartCoroutine(AI.Wait_After_Hit());
    }

    void Update()
    {
        if(Enemy_Health_Value <= 0)
        {
            Destroy(Enemy);
        }
    }
}
