using UnityEngine;

public class Inventory_Menu : MonoBehaviour
{
    public static bool Game_Is_Paused = false;
    public GameObject Inventory_Menu_UI;

    void Pause_Game()
    {
        Inventory_Menu_UI.SetActive(true);
        Time.timeScale = 0;
        Game_Is_Paused = true;
    }

    void Resume_Game()
    {
        Inventory_Menu_UI.SetActive(false);
        Time.timeScale = 1;
        Game_Is_Paused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Game_Is_Paused == true)
            {
                Resume_Game();
            }
            else
            {
                Pause_Game();
            }
        }
    }
}
