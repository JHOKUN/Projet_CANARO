using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Game_Script : MonoBehaviour
{
    public GameObject Player;
    public GameObject Death_UI;
    public Vector2 Player_Position;
    public Transform Last_Resume_Point;
    public Spawn_Point_Definer Player_Position_Storage;

    public void Resume_The_Game()
    {
        Time.timeScale = 1;
        Death_UI.SetActive(false);
        Player.GetComponent<Health_Player>().Healing(100);
        Player.GetComponent<Health_Player>().Player_Animator.SetBool("Is_Dead", false);
        Player_Position_Storage.Spawn_Point_Value = Player_Position;
        Player.GetComponent<Player_Movement>().Must_Respawn = true;
    }

    void Update()
    {
        Player_Position = new Vector2(Last_Resume_Point.position.x, Last_Resume_Point.position.y);
    }
}
