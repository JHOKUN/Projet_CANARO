using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_In_Boss_Room : MonoBehaviour
{
    public Boss_Main bm;
    public GameObject Player;
    public GameObject Teleporter;
    public GameObject Door_Boss;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Player = collider.gameObject;
            bm.Player = collider.gameObject;
            bm.Able_To_Run = true;
            bm.Tick = Time.time + bm.Wait_Time_To_Attack;
            bm.Can_Wait_To_Attack = true;
        }
    }

    void Update()
    {
        if(Player.GetComponent<Player_Achievements>().Boss_Beaten == true)
        {
            Teleporter.SetActive(true);
            Door_Boss.SetActive(false);
        }
    }
}
