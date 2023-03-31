using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Chest_Actvate : MonoBehaviour
{
    public GameObject Player;
    public Animator Chest_Animator;
    public BoxCollider2D Collider;
    public bool Is_Open = false;
    [SerializeField] private int Key_Amount;
    [SerializeField] private int Potion_Amount;
    public bool Player_In_Range = false;




    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = true;
            Player = Collider.gameObject;
        }
    

    }
    void OnTriggerExit2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = false;
        }
    }

    void Update()
    {
        if(Player_In_Range && Input.GetKeyDown(KeyCode.R) && Is_Open == false)
        {
            Chest_Animator.SetTrigger("Open_Chest");
            Player.GetComponent<Inventory_Placeholder>().Add_Key_To_Inventory(Key_Amount);
            Player.GetComponent<Inventory_Placeholder>().Add_Potion_To_Inventory(Potion_Amount);
            Is_Open = true;
        }
    }
}
