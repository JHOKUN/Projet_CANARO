using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail_Position : MonoBehaviour
{
    public Boss_Main bm;
    public Cursor_Position cp;
    public CircleCollider2D cc2d;


    void Update()
    {
        if(bm.Is_Stunned)
        {
            cc2d.enabled = true;

            if(cp.Cursor_Direction == "Right")
            {
                cc2d.transform.localPosition = new Vector2(-0.29f,0-0.063f);
            }
            else if(cp.Cursor_Direction == "Left")
            {
                cc2d.transform.localPosition = new Vector2(0.29f,0-0.063f);
            }
            else if(cp.Cursor_Direction == "Up")
            {
                cc2d.transform.localPosition = new Vector2(0f,-0.305f);
            }
            else if(cp.Cursor_Direction == "Down")
            {
                cc2d.transform.localPosition = new Vector2(0f,0.24f);
            }
        }
        else if(bm.Is_Stunned == false)
        {
            cc2d.enabled = false;
        }

    }
}
