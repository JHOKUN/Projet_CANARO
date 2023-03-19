using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Activate : MonoBehaviour
{   
    public Animator Chest_Animator;
    public BoxCollider2D Collider;
    public bool Is_Open = false;
    [SerializeField] private int Key_Amount;
    [SerializeField] private int Potion_Amount;
    [SerializeField] private bool Is_Getting_Hook;
    public bool Player_In_Range = false;
    public bool Able_To_Open = false;


    void Opening_Condition()
    {
        if(Player_In_Range && Input.GetKeyDown(KeyCode.H) && Is_Open == false)
        {
            Able_To_Open = true;
        }
    }


    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = true;
        }
    

    }
    void OnTriggerExit2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = false;
        }
    }
    
    void OnTriggerStay2D(Collider2D Collider)
    {
        if(Able_To_Open)
        {
            Chest_Animator.SetTrigger("Open_Chest");
            Collider.gameObject.GetComponent<Inventory_Placeholder>().Hook_Getting = Is_Getting_Hook;
            Collider.gameObject.GetComponent<Inventory_Placeholder>().Add_Key_To_Inventory(Key_Amount);
            Collider.gameObject.GetComponent<Inventory_Placeholder>().Add_Potion_To_Inventory(Potion_Amount);
            Is_Open = true;
        }
    }

    void Update()
    {
        Opening_Condition();
    }
    
}
