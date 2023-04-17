using UnityEngine;

public class Camera_Following : MonoBehaviour
{
    public GameObject Player;
    public float Time_Offset;
    public Vector3 Position_Offset;

    private Vector3 Velocity;
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + Position_Offset, ref Velocity, Time_Offset);
    }
}
