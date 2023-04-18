using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_Enemy : MonoBehaviour
{
    public EnemyAI AI;
    public Collider2D Collider;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            AI.Target = collider.gameObject.GetComponent<Transform>();
            Collider.enabled = false;
        }
    } 
}
