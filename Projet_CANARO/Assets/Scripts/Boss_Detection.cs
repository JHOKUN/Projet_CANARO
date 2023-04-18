using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Detection : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    public GameObject Teleporter;
    public BoxCollider2D Collider;
    public int Boss_Death_Count = 0;
    public bool Player_In = false;
    public bool No_More_Boss = false;
    public bool Door_Open = false;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player = collider.gameObject;
            Player_In = true;
        }

        if(collider.gameObject.tag == "Boss")
        {
            No_More_Boss = false;
            Teleporter.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player_In = false;
        }
    }


    void Start()
    {
        Door.SetActive(false);
        Teleporter.SetActive(true);
    }

    void Update()
    {

        if(Player_In == true && No_More_Boss == false)
        {
            Door.SetActive(true); 
        }

        else if(Player_In == true && No_More_Boss == true)
        {
            Door_Open = true;
        }
        if(Player.GetComponent<Player_Achievements>().Boss_Beaten == true)
        {
            Teleporter.SetActive(true);
        }
    }
}
