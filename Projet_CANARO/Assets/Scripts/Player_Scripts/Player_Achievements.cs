using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Achievements : MonoBehaviour
{
    public BoxCollider2D Detector;
    public bool Boss_Beaten = false;
    public bool Chest_1_Opened = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(Boss_Beaten == true)
        {
            if(collider.CompareTag("Enemy"))
            {
                collider.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Boss_Beaten = true;
        }
    }
}
