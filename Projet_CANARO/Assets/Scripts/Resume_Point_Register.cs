using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Point_Register : MonoBehaviour
{
    public BoxCollider2D Collider2D;
    public Vector2 Position;
    [SerializeField] public bool Place_Village;
    [SerializeField] public bool Place_Dungeon_Entrance;
    [SerializeField] public bool Place_Dungeon_Exit;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.CompareTag("Player"))
        {
            Collider.GetComponent<Inventory_Placeholder>().In_Village = Place_Village;
            Collider.GetComponent<Inventory_Placeholder>().Entrance_Dungeon = Place_Dungeon_Entrance;
            Collider.GetComponent<Inventory_Placeholder>().Exit_Dungeon = Place_Dungeon_Exit;
            Collider.GetComponent<Inventory_Placeholder>().New_Pos = Position;
        }
    }
}
