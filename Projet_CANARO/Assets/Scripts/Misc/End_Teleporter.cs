using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Teleporter : MonoBehaviour
{
    public GameObject Ending_UI;
    public BoxCollider2D Collider;
    public Vector2 Position;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Ending_UI.SetActive(true);
            collider.gameObject.transform.position = Position;
        }
    }

    
}
