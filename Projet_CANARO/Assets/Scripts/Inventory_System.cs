using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory_System : MonoBehaviour
{
  public TextMeshProUGUI Key_Count;
  public TextMeshProUGUI Potion_Count;
  public bool Hook_Get = false;
  public int Keys;
  public int Potions;


  public void Add_Potion(int Amount)
  {
    Potions += Amount;
    Potion_Count.text = Potions.ToString();
  }

  public void Remove_Potion(int Amount)
  {
    if(Potions > 0)
    {
      Potions -= Amount;
      Potion_Count.text = Potions.ToString();
    }
    
  }

  public void Add_Key(int Amount)
  {
    Keys += Amount;
    Key_Count.text = Keys.ToString();
  }

  public void Remove_Key(int Amount)
  {
    if(Keys > 0)
    {
      Keys -= Amount;
      Key_Count.text = Keys.ToString();
    }
  }

  
}
