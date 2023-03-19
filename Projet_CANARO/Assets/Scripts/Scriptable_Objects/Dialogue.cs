using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogue_box;
    public bool Is_Dialoguing = false;
    public bool Player_In_Range = false;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = true;
        }
    }
    void OnTriggerExit2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = false;
        }
    }

    void Dialogue_Engaging()
    {
        if(Player_In_Range == true && Input.GetKeyDown(KeyCode.R))
        {
            dialogue_box.SetActive(true);
            Time.timeScale = 0.00000000001f;
            Is_Dialoguing = true;
        }
    }

    
    void Update()
    {
        Dialogue_Engaging();
       
        if (Is_Dialoguing == true && dialogue_box.activeInHierarchy == false)
            {
                dialogue_box.GetComponent<Write_Dialogue>().enabled = false;
                dialogue_box.GetComponent<Write_Dialogue>().enabled = true;
                Time.timeScale = 1;
            }
    }
}
