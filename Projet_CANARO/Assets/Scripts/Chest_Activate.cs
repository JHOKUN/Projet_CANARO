using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Activate : MonoBehaviour
{   
    public Animator Chest_Animator;
    public BoxCollider2D Collider;
    public bool Is_Open = false;
    public int Key_Amount;
    public int Potion_Amount;
    [SerializeField] private bool Is_Getting_Hook;
    public bool Player_In_Range = false;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = true;
        }
    
        if(Player_In_Range && Input.GetKeyDown(KeyCode.H) && Is_Open == false)
        {
            Chest_Animator.SetTrigger("Open_Chest");
            GetComponent<Collider>().gameObject.GetComponent<Inventory_Placeholder>().Hook_Getting = Is_Getting_Hook;
            GetComponent<Collider>().gameObject.GetComponent<Inventory_Placeholder>().Add_Key_To_Inventory(Key_Amount);
            GetComponent<Collider>().gameObject.GetComponent<Inventory_Placeholder>().Add_Potion_To_Inventory(Potion_Amount);
            Is_Open = true;
        }

    }
    void OnTriggerExit2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = false;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
    }
    
}
