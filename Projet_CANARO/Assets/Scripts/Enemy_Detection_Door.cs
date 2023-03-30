using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detection_Door : MonoBehaviour
{
    public GameObject Door_1;
    public GameObject Door_2;
    public BoxCollider2D Collider;
    public bool Player_In = false;
    public bool No_More_Ennemies = false;
    public bool Doors_Open = false;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player_In = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player_In = false;
        }

        if(collider.gameObject.tag == "Enemy")
        {
            No_More_Ennemies = true;
        }
    }


    void Start()
    {
        Door_1.SetActive(false);
        Door_2.SetActive(false);
    }

    void Update()
    {
        if(Player_In == true && No_More_Ennemies == false)
        {
            Door_1.SetActive(true);
            Door_2.SetActive(true); 
        }

        else if(Player_In == true && No_More_Ennemies == true)
        {
            Doors_Open = true;
        }
    }
}
