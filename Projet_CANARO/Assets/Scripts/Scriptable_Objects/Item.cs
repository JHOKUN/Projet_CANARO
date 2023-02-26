using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int Item_Id;
    public string Item_Name;
    public string Item_Description;
    public Sprite Item_Image;
    public GameObject Prefab;
    public int Healing_Amount;

}
