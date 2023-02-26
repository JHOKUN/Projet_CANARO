using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Menu_UI : MonoBehaviour
{
    //public Inventory_System Inventory;
    public Transform Items_Panel;
    Inventory_Slot[] Slots;


     void Update_Inventory_UI()
    {
        for(int i = 0; i < Slots.Length; i++)
        {

            if(i < Inventory_System.instance.Content.Count)
            {
                Slots[i].Add_Item_To_Slot(Inventory_System.instance.Content[i]);
            }
            else
            {
                Slots[i].Slot_Clearing();
            }
        }
    }

    void Start()
    {
        Inventory_System.instance.onItemAddedCallBack += Update_Inventory_UI;

        Slots = Items_Panel.GetComponentsInChildren<Inventory_Slot>();
    }

}
