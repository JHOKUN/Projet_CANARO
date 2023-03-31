using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Activate : MonoBehaviour
{
    public GameObject Player;   
    public Animator Chest_Animator;
    public BoxCollider2D Collider;
    public bool Is_Open = false;
    [SerializeField] private bool Is_Getting_Hook;
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
            Player.GetComponent<Inventory_Placeholder>().Hook_Getting = Is_Getting_Hook;
            Is_Open = true;
        }
    }
    
}
