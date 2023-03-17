using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public string Scene_To_Load;
    public Vector2 Player_Position;
    public Spawn_Point_Definer Player_Position_Storage;
    public bool Change_Scene = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Player_Position_Storage.Spawn_Point_Value = Player_Position;
            SceneManager.LoadScene(Scene_To_Load);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Change_Scene = true;
        }
        if(Change_Scene == true)
        {
            Player_Position_Storage.Spawn_Point_Value = Player_Position;
            SceneManager.LoadScene(Scene_To_Load);
            Change_Scene = false;
        }
    }
}
