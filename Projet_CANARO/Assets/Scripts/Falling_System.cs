using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_System : MonoBehaviour
{
    public Vector2 Player_Position;
    public Spawn_Point_Definer Player_Position_Storage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.gameObject.GetComponent<Shooting_Hook>().Player_Being_Drag == false)
        {
            other.gameObject.GetComponent<Health_Player>().Taking_Damage(1);
            Player_Position_Storage.Spawn_Point_Value = Player_Position;
            other.GetComponent<Player_Movement>().Must_Respawn = true;
        }
    }
}
