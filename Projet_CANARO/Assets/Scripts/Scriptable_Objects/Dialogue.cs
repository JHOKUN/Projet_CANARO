using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogue_box;
    public Player_Movement Movement_Player;
    public bool Is_Dialoguing = false;

    void OnTriggerStay2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player" && Input.GetKey(KeyCode.R))
        {
            player.GetComponent<Player_Movement>().enabled = false;
            Movement_Player.Movement.x = 0;
            Movement_Player.Movement.y = 0;
            dialogue_box.SetActive(true);
            Is_Dialoguing = true;
        }

    }
    
    void Update()
    {
        if (Is_Dialoguing == true && dialogue_box.activeInHierarchy == false)
            {
                dialogue_box.GetComponent<Write_Dialogue>().enabled = false;
                dialogue_box.GetComponent<Write_Dialogue>().enabled = true;
                player.GetComponent<Player_Movement>().enabled = true;
            }
    }
}
