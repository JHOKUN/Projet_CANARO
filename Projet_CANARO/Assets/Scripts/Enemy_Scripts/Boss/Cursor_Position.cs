using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Position : MonoBehaviour
{
    public Boss_Main bm;
    public BoxCollider2D bc2d;

    void Update()
    {

        if (Mathf.Abs(bm.Direction_To_Run.x) > Mathf.Abs(bm.Direction_To_Run.y))
        {
            if (bm.Direction_To_Run.x > 0)
            {
                bc2d.transform.localPosition = new Vector2(1f,0f);
            }
            else
            {
                bc2d.transform.localPosition = new Vector2(-1f,0f);
            }
        }
        else
        {
            if (bm.Direction_To_Run.y > 0)
            {
                bc2d.transform.localPosition = new Vector2(0f,1f);
            }
            else
            {
                bc2d.transform.localPosition = new Vector2(0f,-1f);
            }
        }

        if(bm.Is_Attacking == false)
        {
            bm.Direction_To_Attack = new Vector2(transform.position.x - bm.transform.position.x, transform.position.y - bm.transform.position.y);
        }
    }
}
