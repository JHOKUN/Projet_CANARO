using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Point_Register : MonoBehaviour
{
    public Falling_System Holes;
    public BoxCollider2D Collider2D;
    public Transform Position;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.CompareTag("Player"))
        {
            Collider.GetComponent<Player_Movement>().Last_Check_Point = Position;
            Holes.Last_Check_Point = Position;
        }
    }

}
