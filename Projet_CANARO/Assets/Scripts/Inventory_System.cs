using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_System : MonoBehaviour
{
    public Health_Player Player_Health;
    public List<Item> Content = new List<Item>();



    public void Use_Item()
    {
        Item Current_Item = Content[0];
        Player_Health.Healing(Current_Item.Healing_Amount);
        Content.Remove(Current_Item);
    }



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
