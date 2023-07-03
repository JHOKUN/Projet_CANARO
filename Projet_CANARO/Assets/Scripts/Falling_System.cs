using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_System : MonoBehaviour
{
    public Transform Last_Check_Point;
    public Vector2 Player_Position;
    public Spawn_Point_Definer Player_Position_Storage;
    public PointEffector2D effector;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.gameObject.GetComponent<Shooting_Hook>().Player_Being_Drag == false && other.gameObject.GetComponent<Player_Movement>().Is_Dashing == false)
        {
            StartCoroutine(Fall(other));
        }
    }
    
    IEnumerator Fall(Collider2D Player)
    {
        Player.GetComponent<Player_Movement>().Is_Falling = true;
        Player.GetComponent<Player_Movement>().Able_To_Dash = false;
        effector.enabled = true;
        yield return new WaitForSeconds(1f);
        effector.enabled = false;
        Player.GetComponent<Player_Movement>().Fall();
        Player_Position_Storage.Spawn_Point_Value = Player_Position;
        yield return new WaitForSeconds(1f);
        Player.GetComponent<Player_Movement>().Must_Respawn = true;
        Player.GetComponent<Player_Movement>().Is_Falling = false;
        Player.GetComponent<Player_Movement>().Player_Animator.SetBool("Is_Facing_Foreward", true);
        Player.gameObject.GetComponent<Health_Player>().Taking_Damage(1);
        Player.GetComponent<Player_Movement>().Able_To_Dash = true;    
    }

    void Start()
    {
        effector.enabled = false;
    }

    void Update()
    {
        Player_Position = new Vector2(Last_Check_Point.position.x, Last_Check_Point.position.y);
    }
}
