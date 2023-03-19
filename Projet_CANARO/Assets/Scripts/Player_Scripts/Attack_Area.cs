using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Area : MonoBehaviour
{
    public CapsuleCollider2D Attack_Zone;
    public Enemy_Health Enemy_Life;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Enemy")
        {
            Collider.GetComponent<Enemy_Health>().Enemy_Health_Value -= 1;
        }
    }

    void Update()
    {
        
    }
}
