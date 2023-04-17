using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Clip_Definer : MonoBehaviour
{
    public BoxCollider2D Collider;
    [SerializeField] public bool Current_Clip_Village;
    [SerializeField] public bool Current_Clip_Dungeon;
    [SerializeField] public bool Current_Clip_Shop;

    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.GetComponent<Inventory_Placeholder>().Clip_Is_Village = Current_Clip_Village;
        collider.gameObject.GetComponent<Inventory_Placeholder>().Clip_Is_Dungeon = Current_Clip_Dungeon;
        collider.gameObject.GetComponent<Inventory_Placeholder>().Clip_Is_Shop = Current_Clip_Shop;
    }
}
