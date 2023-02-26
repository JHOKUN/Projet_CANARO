using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    public Item New_Item;               // Le problème vient du fait que les slots n'ont pas tous et pas toujours d'item 
    public Image Item_Icon;
    public int Slot_Index;
    public Use_Selected_Item Player_Using;

    public void Add_Item_To_Inventory(Item New_Item)
    {
        Inventory_System.instance.Content.Add(New_Item);
    }

    public void Add_Item_To_Slot(Item New_Item)
    {
        Debug.Log("Slot updated");
        Item_Icon.sprite = New_Item.Item_Image;
        Item_Icon.enabled = true;
    }

    public void Slot_Clearing()
    {
        New_Item = null;
        Item_Icon.sprite = null;
        Item_Icon.enabled = false;
    }


    public void Item_Selection()
    {
        if(New_Item != null)
        {   
            Inventory_System.instance.Current_Item = New_Item;
            Debug.Log("ça detecte");
            Player_Using.Able_To_Use = true;
        }
    }
    void Update()
    {
    }
}