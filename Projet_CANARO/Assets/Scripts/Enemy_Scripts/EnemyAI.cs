using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float Speed;
    public Transform Target;
    public float Minimum_Distance;
    public float Maximum_Distance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) > Minimum_Distance && Vector2.Distance(transform.position, Target.position) < Maximum_Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
        //else BAM le coup de lance 
        

    }
}
