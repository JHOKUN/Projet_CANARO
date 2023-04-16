using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Button : MonoBehaviour
{
    public GameObject Ending_UI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main_Land");
            Ending_UI.SetActive(false);
        }
    }
}
