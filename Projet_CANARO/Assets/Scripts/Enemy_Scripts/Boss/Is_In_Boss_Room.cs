using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_In_Boss_Room : MonoBehaviour
{
    public Boss_Main bm;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            bm.Player = collider.gameObject;
            bm.Able_To_Run = true;
            bm.Tick = Time.time + bm.Wait_Time_To_Attack;
            bm.Can_Wait_To_Attack = true;

        }
    } 
}
