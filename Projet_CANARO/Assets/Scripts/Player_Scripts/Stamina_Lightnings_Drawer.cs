using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina_Lightnings_Drawer : MonoBehaviour
{
    public GameObject LightningPrefab;
    public Player_Movement Movement_Player;
    List<Stamina_System> Lightnings = new List<Stamina_System>();

    public void Start()
    {
        Lightnings_Drawing();
    }

    public void Update()
    {
        Lightnings_Drawing();
    }

    private void OnEnable()
    {
        Player_Movement.OnPlayerDashed += Lightnings_Drawing;
        Debug.Log("Le dash est pris en compte");
    }

     private void OnDisable()
    {
        Player_Movement.OnPlayerDashed -= Lightnings_Drawing;
    }

    public void  Lightnings_Clearing()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);           
        }
            Lightnings = new List<Stamina_System>();
    }

    public void Create_Filled_Lightnings()
    {
        GameObject New_Lightning = Instantiate(LightningPrefab);
        New_Lightning.transform.SetParent(transform);

        Stamina_System LightningsComponent = New_Lightning.GetComponent<Stamina_System>();
        LightningsComponent.Lightning_Image_Setting(Stamina_System.Stamina_Status.Filled);
        Lightnings.Add(LightningsComponent);
    }

    public void Lightnings_Drawing()
    {
        Lightnings_Clearing();
        int Lightnings_Needed_To_Make =(int)(Movement_Player.Max_Player_Stamina);
        for(int i = 0; i < Lightnings_Needed_To_Make; i++)
        {
            Create_Filled_Lightnings();
        }
    }

}