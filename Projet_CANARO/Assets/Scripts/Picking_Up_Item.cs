using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking_Up_Item : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D Collider;
    public int Potion_Amount;
    public bool Has_Been_Picked_Up = false;
    public bool Player_In = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Player_In = true;
            Player = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Player_In = false;
        }
    }

    void Update()
    {
        if(Player_In == true && Input.GetKeyDown(KeyCode.R) && Has_Been_Picked_Up == false)
        {
            Player.GetComponent<Inventory_Placeholder>().Add_Potion_To_Inventory(Potion_Amount);
            Has_Been_Picked_Up = true;
        }
    }
}
