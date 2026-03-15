using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        if (player!=null)
        {
            transform.position = player.position + new Vector3(0,0,-10);
        }
    }
}
