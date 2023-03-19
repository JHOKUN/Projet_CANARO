using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    public Inventory_System Inventory;
    public Image Item_Displaying;
    
    void Start()
    {
        Item_Displaying.enabled = false;
    }

    void Update()
    {
        if(Inventory.Hook_Get == true)
        {
            Item_Displaying.enabled = true;
        }
    }
}