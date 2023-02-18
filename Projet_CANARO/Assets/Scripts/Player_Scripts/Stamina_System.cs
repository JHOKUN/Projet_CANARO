using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina_System : MonoBehaviour
{
    public Sprite Empty_Lightning, Filled_Lightning;
    Image Lightning_Image;

    private void Awake()
    {
        Lightning_Image = GetComponent<Image>();
    }

    public enum Stamina_Status
    {
        Empty = 0,
        Filled = 1
    }

    public void Lightning_Image_Setting(Stamina_Status Status)
   {
        switch (Status)
        {
            case Stamina_Status.Empty:
                Lightning_Image.sprite = Empty_Lightning;
                break;
            case Stamina_Status.Filled:
                Lightning_Image.sprite = Filled_Lightning;
                break;
            
        }
   }

}
