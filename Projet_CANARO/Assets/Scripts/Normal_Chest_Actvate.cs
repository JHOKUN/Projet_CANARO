using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Chest_Actvate : MonoBehaviour
{
    public GameObject Player;
    public Animator Chest_Animator;
    public BoxCollider2D Collider;
    public bool Is_Open = false;
    [SerializeField] private int Key_Amount;
    [SerializeField] private int Potion_Amount;
    [SerializeField] public bool Opened_2;
    [SerializeField] public bool Opened_3;
    public bool Player_In_Range = false;
    public GameObject dialogue_box;
    public bool Is_Dialoguing = false;




    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = true;
            Player = Collider.gameObject;
        }
    

    }
    void OnTriggerExit2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Player_In_Range = false;
        }
    }

    IEnumerator Opening_Chest()
    {
        Chest_Animator.SetTrigger("Open_Chest");
        Player.GetComponent<Inventory_Placeholder>().Add_Key_To_Inventory(Key_Amount);
        Player.GetComponent<Inventory_Placeholder>().Add_Potion_To_Inventory(Potion_Amount);
        Player.GetComponent<Player_Achievements>().Chest_2_Opened = Opened_2;
        Player.GetComponent<Player_Achievements>().Chest_3_Opened = Opened_3;
        yield return new WaitForSeconds(1f);
        dialogue_box.SetActive(true);
        Time.timeScale = 0.00000000001f;
        Is_Dialoguing = true;
    }
    
    void Update()
    {
        if(Player_In_Range && Input.GetKeyDown(KeyCode.R) && Is_Open == false)
        {
            StartCoroutine(Opening_Chest());
            Is_Open = true;
        }

        if (Is_Dialoguing == true && dialogue_box.activeInHierarchy == false)
            {
                dialogue_box.GetComponent<Write_Dialogue>().enabled = false;
                dialogue_box.GetComponent<Write_Dialogue>().enabled = true;
                Time.timeScale = 1;
            }
        
    }
}
