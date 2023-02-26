using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_System : MonoBehaviour
{
    
    public Health_Player Player_Health;
    public Inventory_Slot Slots;
    public List<Item> Content = new List<Item>();
    public Item Current_Item;
    public int Content_Current_Index = 0;
    public int Inventory_Space = 9;
    public static Inventory_System instance;

    public delegate void OnItemAdded();
    public OnItemAdded onItemAddedCallBack;

    public void Use_Item()
    {
        Item Current_Item = Content[Content_Current_Index];
        Player_Health.Healing(Current_Item.Healing_Amount);
        Slots.Slot_Clearing();
        Content.Remove(Current_Item);
    }
    
    public void Add_Item(Item item)
    {
        if(Content.Count >= Inventory_Space)
        {
            Debug.Log("Inventaire plein");
            return;
        }

        Content.Add(item);
        Debug.Log("Item added");

        if(onItemAddedCallBack != null)
        {
            onItemAddedCallBack.Invoke();
        }
    }

    //public void Get_Next_Item()
    //{
      //  Content_Current_Index += 1;
    //}

    //public void Get_Previous_Item()
    //{
      //  Content_Current_Index -= 1;
    //}                                                                                     On réutilisera ça pour la case qui montre l'objet selectionné (si on a le temps)

    //void Update_Inventory_UI(int Content_Current_Index)
    //{
      //  Item_Icon.sprite = Content[Content_Current_Index].Item_Image;
    //}


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
