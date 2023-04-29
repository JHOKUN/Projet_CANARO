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
        if(collider.gameObject.name == "Chest_2" && Chest_2_Opened == true)
        {
            collider.gameObject.SetActive(false);
        }
        if(collider.gameObject.name == "Chest_1" && Chest_3_Opened == true)
        {
            collider.gameObject.SetActive(false);
        }
        if(collider.CompareTag("Button") && Door_1_Opened == true)
        {
            collider.GetComponent<Door_Room_Open>().Activate = true;
        }
        if(collider.gameObject.name == "Key_Door" && Door_2_Opened == true)
        {
            collider.GetComponent<Key_Door_Open>().Activate = true;
        }
        if(collider.CompareTag("Boss") && Boss_Beaten == true)
        {
            collider.gameObject.SetActive(false);
        }
    }
}
