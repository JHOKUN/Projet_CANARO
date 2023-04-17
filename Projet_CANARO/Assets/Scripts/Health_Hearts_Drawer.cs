using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Hearts_Drawer : MonoBehaviour
{
    public GameObject HeartPrefab;
    public Health_Player Player_Health;
    List<Health_System> hearts = new List<Health_System>();

    public void Start()
    {
        Hearts_Drawing();
    }

    public void Update()
    {
        Hearts_Drawing();
    }

    private void OnEnable()
    {
        Health_Player.OnPlayerDamaged += Hearts_Drawing;
    }

    private void OnDisable()
    {
        Health_Player.OnPlayerDamaged -= Hearts_Drawing;
    }
    


    public void  Hearts_Clearing()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);           
        }
            hearts = new List<Health_System>();
    }


    public void Create_Filled_Heart()
    {
        GameObject New_Heart = Instantiate(HeartPrefab);
        New_Heart.transform.SetParent(transform);

        Health_System heartsComponent = New_Heart.GetComponent<Health_System>();
        heartsComponent.Heart_Image_Setting(Health_System.Heart_Status.Filled);
        hearts.Add(heartsComponent);
    }

    public void Hearts_Drawing()
    {
        Hearts_Clearing();
        float Max_Player_Health_Remainder = Player_Health.Max_Player_Health % 2;
        int Hearts_Needed_To_Make =(int)(Player_Health.Max_Player_Health / 2 + Max_Player_Health_Remainder);
        for(int i = 0; i < Hearts_Needed_To_Make; i++)
        {
            Create_Filled_Heart();
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int Heart_Status_Remainder = (int)Mathf.Clamp(Player_Health.Current_Player_Health - (i*2), 0, 2);
            hearts[i].Heart_Image_Setting((Health_System.Heart_Status)Heart_Status_Remainder);
        }

    }


}
