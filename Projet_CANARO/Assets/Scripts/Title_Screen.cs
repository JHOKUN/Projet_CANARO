using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Screen : MonoBehaviour
{
    public static bool Game_Started = false;
    public GameObject Title_Screen_UI;

    public void Starting_Game()
    {
        Title_Screen_UI.SetActive(false);
        Game_Started = true;
        SceneManager.LoadScene("House_Inside_1");
    }

    void Update()
    {
        if(Game_Started == false)
        {
            Title_Screen_UI.SetActive(true);
        }
        else if(Game_Started == false && Input.GetKeyDown(KeyCode.Return))
        {
            Starting_Game();
        }
    }
}
