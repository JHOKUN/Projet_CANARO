using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Placeholder : MonoBehaviour
{
    public GameObject Audio_Manager;
    public Resume_Game_Script Resume;
    public Inventory_System Real_Inventory;
    public Vector2 New_Pos;
    public Animator Fader;
    public bool Clip_Is_Village = false;
    public bool Clip_Is_Dungeon = false;
    public bool Clip_Is_Shop = false;
    public bool Clip_Is_Boss = false;
    public bool In_Village;
    public bool Entrance_Dungeon;
    public bool Exit_Dungeon;
    public bool Hook_Getting = false;
    public bool Has_Key = false;
    public bool Must_Fade = false;

    public void Add_Potion_To_Inventory(int Amount)
    {
        Real_Inventory.Add_Potion(Amount);
    }

    public void Remove_Potion_To_Inventory(int Amount)
    {
        Real_Inventory.Remove_Potion(Amount);
    }

    public void Add_Key_To_Inventory(int Amount)
    {
        Real_Inventory.Add_Key(Amount);
    }

    public void Remove_Key_To_Inventory(int Amount)
    {
        Real_Inventory.Remove_Key(Amount);
    }

    IEnumerator Fade()
    {
        if(Must_Fade == true)
        {
            Fader.SetBool("Fading", true);
            yield return new WaitForSeconds(0.1f);
            Fader.SetBool("Fading", false); 
            Must_Fade = false;
        }
    }
    public void Update_Bools()
    {
        Resume.Last_Place_Village = In_Village;
        Resume.Last_Place_Dungeon_Entrance = Entrance_Dungeon;
        Resume.Last_Place_Dungeon_Exit = Exit_Dungeon;
        Resume.Last_Resume_Point = New_Pos;
    }

    void Update_Audio()
    {
        Audio_Manager.GetComponent<Audio_Player>().Play_Village = Clip_Is_Village;
        Audio_Manager.GetComponent<Audio_Player>().Play_Dungeon = Clip_Is_Dungeon;
        Audio_Manager.GetComponent<Audio_Player>().Play_Shop = Clip_Is_Shop;
    }
    void Update()
    {
        Update_Bools();
        Update_Audio();
        StartCoroutine(Fade());

        if(Hook_Getting == true)
        {
            Real_Inventory.Hook_Get = true;
        }

        if(Real_Inventory.Keys > 0)
        {
            Has_Key = true;
        }

    }
}
