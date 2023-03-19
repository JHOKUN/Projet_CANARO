using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookable_Object_Script : MonoBehaviour
{
    public GameObject Player;
    public Collider2D Collider;
    public Transform Target;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Hook")
        {
            Player.GetComponent<Shooting_Hook>().Player_Being_Drag = true;
            Player.GetComponent<Player_Movement>().Set_Target(Target);
            Player.GetComponent<Player_Movement>().Player_Must_Drag = true;
            if(Player.GetComponent<Player_Movement>().Player_Must_Drag == false)
            {
                Player.GetComponent<Shooting_Hook>().Player_Being_Drag = false;
            }
        }

        Player.GetComponent<Shooting_Hook>().Player_Being_Drag = false;
    }
    void Update()
    {
        Debug.Log(Player);
    }
}
