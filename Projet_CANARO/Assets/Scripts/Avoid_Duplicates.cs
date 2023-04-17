using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid_Duplicates : MonoBehaviour
{
    public static Avoid_Duplicates Instance;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
    }
}
