using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_System : MonoBehaviour
{

    public Sprite Empty_Heart, Half_Filled_Heart, Filled_Heart;
    Image Heart_Image;


    private void Awake()
    {
        Heart_Image = GetComponent<Image>();
    }

    public enum Heart_Status
    {
        Empty = 0,
        Half_Filled = 1,
        Filled = 2
    }
    
   public void Heart_Image_Setting(Heart_Status Status)
   {
        switch (Status)
        {
            case Heart_Status.Empty:
                Heart_Image.sprite = Empty_Heart;
                break;
            case Heart_Status.Half_Filled:
                Heart_Image.sprite = Half_Filled_Heart;
                break;
            case Heart_Status.Filled:
                Heart_Image.sprite = Filled_Heart;
                break;
            
        }
   }

}