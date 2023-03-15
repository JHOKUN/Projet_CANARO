using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookable_Object_Script : MonoBehaviour
{
    public Collider2D Collider;
    public Transform Target;
    public Player_Movement Movement_Player;
    public Shooting_Hook Player_Condition;
    public bool Player_Must_Drag = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Hook")
        {
            Player_Condition.Player_Being_Drag = true;
            Movement_Player.Set_Target(Target);
            Player_Must_Drag = true;
            if(Player_Must_Drag == false)
            {
                Player_Condition.Player_Being_Drag = false;
            }
        }

        Player_Condition.Player_Being_Drag = false;
    }
}
