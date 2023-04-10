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
    public GameObject dialogue_box;
    public bool Is_Dialoguing = false;

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

    void Dialogue_Engaging()
    {
        if(Player_In_Range == true && Input.GetKeyDown(KeyCode.R))
        {
            dialogue_box.SetActive(true);
            Time.timeScale = 0.00000000001f;
            Is_Dialoguing = true;
        }
    }
    void Update()
    {
        if(Player_In == true && Input.GetKeyDown(KeyCode.R) && Has_Been_Picked_Up == false)
        {
            Player.GetComponent<Inventory_Placeholder>().Add_Potion_To_Inventory(Potion_Amount);
            if (Is_Dialoguing == true && dialogue_box.activeInHierarchy == false)
                {
                    dialogue_box.GetComponent<Write_Dialogue>().enabled = false;
                    dialogue_box.GetComponent<Write_Dialogue>().enabled = true;
                    Time.timeScale = 1;
                }
            Has_Been_Picked_Up = true;
        }
    }
}
