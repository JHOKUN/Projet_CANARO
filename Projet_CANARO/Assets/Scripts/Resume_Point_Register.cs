using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Point_Register : MonoBehaviour
{
    public Resume_Game_Script Script_Resume_Game;
    public BoxCollider2D Collider2D;
    public Transform Position;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.CompareTag("Player"))
        {
            Script_Resume_Game.Last_Resume_Point = Position;
        }
    }
}
