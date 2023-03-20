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
            Holes.Last_Check_Point = Position;
        }
    }

}
