using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public string Scene_To_Load;

    void OnTriggerEnter2D ()
    {

        SceneManager.LoadScene(Scene_To_Load);

    }
}
