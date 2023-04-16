using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Door_Open : MonoBehaviour
{
    public BoxCollider2D Collider;
    public Animator Key_Door_Animator;
    public bool Activate;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && collider.GetComponent<Inventory_Placeholder>().Has_Key == true)
        {
            collider.GetComponent<Inventory_Placeholder>().Remove_Key_To_Inventory(1);
            collider.GetComponent<Player_Achievements>().Door_2_Opened = true;
            Key_Door_Animator.SetTrigger("Open_Door");
        }
    }

    void Update()
    {
        if(Activate == true)
        {
            Key_Door_Animator.SetTrigger("Open_Door");
        }
    }
    
}
