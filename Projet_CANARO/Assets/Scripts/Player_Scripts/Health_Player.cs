using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Player : MonoBehaviour
{
    public float Max_Player_Health;
    public float Current_Player_Health;
    public static event Action OnPlayerDamaged;
    
    public void Start()
    {
        Current_Player_Health = Max_Player_Health;
        OnPlayerDamaged?.Invoke();
    }

    public void Taking_Damage(int Damage_Amount)
    {
        Current_Player_Health -= Damage_Amount;
    }

    public void Healing(int Healing_Amount)
    {
        Current_Player_Health += Healing_Amount;
        if(Current_Player_Health > Max_Player_Health)
        {
            Current_Player_Health = Max_Player_Health;
        }
    }

}
