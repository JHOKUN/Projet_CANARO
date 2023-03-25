using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_In_Boss_Room : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player = other.gameObject;
            Debug.Log("Player");
        }
    }
}
