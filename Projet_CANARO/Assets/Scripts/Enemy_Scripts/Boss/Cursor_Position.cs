using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Position : MonoBehaviour
{
    public Boss_Main bm;
    public BoxCollider2D bc2d;
    public string Cursor_Direction;

    void Update()
    {
        if(bm.Is_Attacking == false)
        {
            if (Mathf.Abs(bm.Direction_To_Run.x) > Mathf.Abs(bm.Direction_To_Run.y))
            {
                if (bm.Direction_To_Run.x > 0)
                {
                    bc2d.transform.localPosition = new Vector2(1f,0f);
                    Cursor_Direction = "r";
                }
                else
                {
                    bc2d.transform.localPosition = new Vector2(-1f,0f);
                    Cursor_Direction = "g";
                }
            }
            else
            {
                if (bm.Direction_To_Run.y > 0)
                {
                    bc2d.transform.localPosition = new Vector2(0f,1f);
                    Cursor_Direction = "h";
                }
                else
                {
                    bc2d.transform.localPosition = new Vector2(0f,-1f);
                    Cursor_Direction = "b";
                }  
            }
        }

        if(bm.Is_Attacking == false || bm.Is_Stunned == false)
        {
            bm.Direction_To_Attack = new Vector2(transform.position.x - bm.transform.position.x, transform.position.y - bm.transform.position.y);
        }
    }
}
