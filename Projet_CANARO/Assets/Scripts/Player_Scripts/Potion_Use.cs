using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Use : MonoBehaviour
{
    public Inventory_System Inventory;
    public Health_Player Health;
    public bool Able_To_Use = true;
    
    void Use_Potion()
    {
        if(Able_To_Use == true && Inventory.Potions > 0 && Health.Current_Player_Health < Health.Max_Player_Health && Input.GetKeyDown(KeyCode.H))
        {
            Inventory.Remove_Potion(1);
            Health.Healing(2);
        }
    }
    
    void Update()
    {
        Use_Potion();
    }
}
