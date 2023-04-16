using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Detection : MonoBehaviour
{
    public GameObject Door;
    public BoxCollider2D Collider;
    public int Boss_Death_Count = 0;
    public bool Player_In = false;
    public bool No_More_Boss = false;
    public bool Door_Open = false;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player_In = true;
        }

        if(collider.gameObject.tag == "Boss")
        {
            No_More_Boss = false;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player_In = false;
        }

        if(collider.gameObject.tag == "Boss")
        {
            Boss_Death_Count += 1;
        }
    }


    void Start()
    {
        Door.SetActive(false);
    }

    void Update()
    {
        if(Boss_Death_Count == 1)
        {
            No_More_Boss = true;
        }

        if(Player_In == true && No_More_Boss == false)
        {
            Door.SetActive(true); 
        }

        else if(Player_In == true && No_More_Boss == true)
        {
            Door_Open = true;
        }
    }
}
