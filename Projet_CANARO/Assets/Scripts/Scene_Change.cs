using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public string Scene_To_Load;
    public Vector2 Player_Position;
    public Vector2 Position_To_Load;
    public Spawn_Point_Definer Player_Position_Storage;
    public Animator Fade;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Player_Position_Storage.Spawn_Point_Value = Player_Position;
            other.GetComponent<Inventory_Placeholder>().Must_Fade == true;
            SceneManager.LoadScene(Scene_To_Load);
            other.transform.position = Position_To_Load;
        }
    }
}
