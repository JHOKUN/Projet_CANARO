using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Change : MonoBehaviour
{
    public BoxCollider2D Collider;
    public GameObject Mij;
    public GameObject New_Dialogue;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Player_Achievements>().Boss_Beaten == true)
        {
            Mij.GetComponent<Dialogue>().dialogue_box = New_Dialogue;
        }
    }
}
