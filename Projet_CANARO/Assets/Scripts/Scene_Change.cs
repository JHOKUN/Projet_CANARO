using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public string Scene_To_Load;
    public Vector2 Player_Position;
    public Spawn_Point_Definer Player_Position_Storage;

    void OnTriggerEnter2D ()
    {
       
            Player_Position_Storage.Spawn_Point_Value = Player_Position;
            SceneManager.LoadScene(Scene_To_Load);

    }
}
