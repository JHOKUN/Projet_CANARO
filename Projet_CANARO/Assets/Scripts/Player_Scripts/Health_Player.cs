using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : MonoBehaviour
{
    public GameObject Player;
    public GameObject Health;
    public GameObject Stamina;
    public GameObject Death_UI;
    public Animator Player_Animator;
    public Transform Death_Position;
    public float Max_Player_Health;
    public float Current_Player_Health;
    public static event Action OnPlayerDamaged;
    public bool Is_Dead = false;
    public bool Can_Take_Damage = true;
    public float Invicibility = 2f;
    public float Tick;
    
    public void Start()
    {
        Current_Player_Health = Max_Player_Health;
        OnPlayerDamaged?.Invoke();
    }

    public void Taking_Damage(int Damage_Amount)
    {
        if (Can_Take_Damage == true)
        {
           Current_Player_Health -= Damage_Amount; 
        }

        Can_Take_Damage = false;
        
        if (Time.time > Tick)
        {
            Tick = Time.time + Invicibility;
            Can_Take_Damage = true;
        }
        
    }

    public void Healing(int Healing_Amount)
    {
        Current_Player_Health += Healing_Amount;
        if(Current_Player_Health > Max_Player_Health)
        {
            Current_Player_Health = Max_Player_Health;
        }
    }

    IEnumerator Dying()
    {
        Player_Animator.SetBool("Is_Dead", true);
        Is_Dead = true;
        Player.transform.position = Death_Position.position;
        yield return new WaitForSeconds(2f);
        Health.SetActive(false);
        Stamina.SetActive(false);
        Death_UI.SetActive(true);
        Time.timeScale = 0.00000000001f;

    }
    void Update()
    {
        if(Current_Player_Health == 0 && Is_Dead == false)
        {
            StartCoroutine(Dying());
        }
    }

}
