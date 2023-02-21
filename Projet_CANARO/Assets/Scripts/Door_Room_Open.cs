using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Room_Open : MonoBehaviour
{
    public bool Door_Opening = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Door_Opening = true;
        }
    }
}
