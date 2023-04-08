using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_In_Boss_Room : MonoBehaviour
{
    public bool Is_In_Boss_Room_Bool;
    public GameObject Player; 

    void Start()
    {
        Is_In_Boss_Room_Bool = false;
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Is_In_Boss_Room_Bool = true;
            Player = other.gameObject;
        }
    }
}
