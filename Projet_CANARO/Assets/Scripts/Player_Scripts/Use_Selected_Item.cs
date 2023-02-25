using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Selected_Item : MonoBehaviour
{
    public Inventory_System Player_Inventory;
    public bool Able_To_Use = true;
    
    //il faut créer un event UI qui utilisera l'Item, event qui sera Trigger par l'input use item

    public void Use()
    {
        if(Input.GetKey(KeyCode.X) && Able_To_Use == true)
        {
            Player_Inventory.Use_Item();
            Debug.Log("Item used");
            Able_To_Use = false;
        }
    }

    void Update()
    {
       
    }
}
