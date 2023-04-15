using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Damaging_Boss : MonoBehaviour
{
    public Boss_Main bm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && bm.Is_Stunned == false)
        {
            collision.gameObject.GetComponent<Health_Player>().Taking_Damage(1);
        }
    }
}