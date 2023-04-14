using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume_Game_Script : MonoBehaviour
{
    public GameObject Player;
    public GameObject Death_UI;
    public GameObject Health;
    public GameObject Stamina;
    public Vector2 Player_Position;
    public Transform Last_Resume_Point;
    public Spawn_Point_Definer Player_Position_Storage;
    public bool Last_Place_Village = true;
    public bool Last_Place_Dungeon_Entrance = false;
    public bool Last_Place_Dungeon_Exit = false;

    public void Resume_The_Game()
    {
        Health.SetActive(true);
        Stamina.SetActive(true);
        Time.timeScale = 1;
        Player.GetComponent<Health_Player>().Healing(100);
        Player.GetComponent<Health_Player>().Player_Animator.SetBool("Is_Dead", false);
        if(Last_Place_Village == true || Last_Place_Dungeon_Exit == true)
        {
            SceneManager.LoadScene("Main_Land");
            Player_Position_Storage.Spawn_Point_Value = Player_Position;
        }
        else if(Last_Place_Dungeon_Entrance == true)
        {
            SceneManager.LoadScene("Dungeon_Floor_1");
            Player_Position_Storage.Spawn_Point_Value = Player_Position;
        }
        Player.GetComponent<Player_Movement>().Must_Respawn = true;
    }

    void Update()
    {
        Player_Position = new Vector2(Last_Resume_Point.position.x, Last_Resume_Point.position.y);

        if(Player.GetComponent<Health_Player>().Is_Dead == true);
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Death_UI.SetActive(false);
                Resume_The_Game();
                Player.GetComponent<Health_Player>().Is_Dead = false;
            }
        }
    }
}
