using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Achievements : MonoBehaviour
{
    public BoxCollider2D Detector;
    public bool Boss_Beaten = false;
    public bool Chest_1_Opened = false;
    public bool Chest_2_Opened = false;
    public bool Chest_3_Opened = false;
    public bool Door_1_Opened = false;
    public bool Door_2_Opened = false; 
    public bool Door_3_Opened = false;
    public bool Door_4_Opened = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(Boss_Beaten == true && collider.CompareTag("Enemy"))
        {
            collider.gameObject.SetActive(false);
        }
        if(collider.GetComponent<Chest_Activate>() && Chest_1_Opened == true)
        {
            collider.gameObject.SetActive(false);
        }
        if(collider.GetComponent<Normal_Chest_Actvate>() && Chest_2_Opened == true)
        {
            collider.gameObject.SetActive(false);
        }
        if(collider.GetComponent<Normal_Chest_Actvate>() && Chest_3_Opened == true)
        {
            collider.gameObject.SetActive(false);
        }
        if(collider.CompareTag("Button") && Door_1_Opened == true)
        {
            collider.GetComponent<Door_Room_Open>().Activate = true;
        }
        if(collider.GetComponent<Key_Door_Open>() && Door_2_Opened == true)
        {
            collider.GetComponent<Key_Door_Open>().Activate = true;
        }
        if(collider.GetComponent<Enemy_Detection_Door>() && Door_3_Open)
        {
            collider.GetComponent<Enemy_Detection_Door>().Doors_Open = true;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Boss_Beaten = true;
        }
    }
}
