using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Placeholder : MonoBehaviour
{
    public Resume_Game_Script Resume;
    public Inventory_System Real_Inventory;
    public Transform New_Pos;
    public Animator Fader;
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

    void Update()
    {
        Update_Bools();
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
