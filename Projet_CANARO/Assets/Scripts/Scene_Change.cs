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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Changing_Scene(other));
        }
    }

    IEnumerator Changing_Scene(Collider2D other)
    {
        Player_Position_Storage.Spawn_Point_Value = Player_Position;
        other.GetComponent<Inventory_Placeholder>().Must_Fade = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Scene_To_Load);
        other.transform.position = Position_To_Load;
    }
}
