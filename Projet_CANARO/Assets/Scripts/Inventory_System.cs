using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_System : MonoBehaviour
{
    public Image Item_Icon;
    public Health_Player Player_Health;
    public List<Item> Content = new List<Item>();
    public int Content_Current_Index = 0;



    public void Use_Item()
    {
        Item Current_Item = Content[Content_Current_Index];
        Player_Health.Healing(Current_Item.Healing_Amount);
        Content.Remove(Current_Item);
    }
    

    public void Get_Next_Item()
    {
        Content_Current_Index += 1;
    }

    public void Get_Previous_Item()
    {
        Content_Current_Index -= 1;
    }

    void Update_Inventory_UI(int Content_Current_Index)
    {
        Item_Icon.sprite = Content[Content_Current_Index].Item_Image;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
