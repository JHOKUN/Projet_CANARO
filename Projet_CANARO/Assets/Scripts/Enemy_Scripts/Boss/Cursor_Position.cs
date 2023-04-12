using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Position : MonoBehaviour
{
    public Boss_Main bm;
    public BoxCollider2D bc2d;

    void Update()
    {
        if (Mathf.Abs(bm.Direction.x) > Mathf.Abs(bm.Direction.y))
        {
            if (bm.Direction.x > 0)
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
            if (bm.Direction.y > 0)
            {
                bc2d.transform.localPosition = new Vector2(0f,1f);
            }
            else
            {
                bc2d.transform.localPosition = new Vector2(0f,-1f);
            }
        }
    }
}
