using UnityEngine;

public class Keep_Between_Scenes : MonoBehaviour
{
    public GameObject[] Objects;
    
    void Awake()
    {
        foreach (var elements in Objects)
        {
            DontDestroyOnLoad(elements);
        }
    }
}
