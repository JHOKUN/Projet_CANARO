using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Start_Position : MonoBehaviour
{
    public GameObject Cursor;

    void Update()
    {
        transform.localPosition = Cursor.transform.localPosition.normalized;
    }
}
