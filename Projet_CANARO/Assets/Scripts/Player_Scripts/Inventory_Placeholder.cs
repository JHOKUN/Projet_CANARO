using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Placeholder : MonoBehaviour
{
    public Inventory_System Real_Inventory;
    public bool Hook_Getting = false;

    public void Add_Potion_To_Inventory(int Amount)
    {
        Real_Inventory.Add_Potion(Amount);
    }

    public void Remove_Potion_To_Inventory(int Amount)
    {
        Real_Inventory.Remove_Potion(Amount);
    }

    public void Add_Key_To_Inventory(int Amount)
    {
        Real_Inventory.Add_Key(Amount);
    }

    public void Remove_Key_To_Inventory(int Amount)
    {
        Real_Inventory.Remove_Key(Amount);
    }

    void Update()
    {
        if(Hook_Getting == true)
        {
            Real_Inventory.Hook_Get = true;
        }
    }
}
