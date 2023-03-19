using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Collider2D Collider;
    public Hookable_Object_Script Script;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Script.Player = collider.gameObject;
            Debug.Log("c bon");
        }
    }
}
