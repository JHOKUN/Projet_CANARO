using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Player : MonoBehaviour
{
    public GameObject Player;
    public AudioClip[] Clips;
    public AudioSource Source;
    public bool Play_Village = false;
    public bool Play_Dungeon = false;

    void Clip_Define()
    {
        if(Play_Village == true)
        {
            Source.clip = Clips[0];
        }
        else if(Play_Dungeon == true)
        {
            Source.clip = Clips[1];
        }
    }
    void Update()
    {
        Clip_Define();

        if(!Source.isPlaying)
        {
            Source.Play();
        }
    }
}
