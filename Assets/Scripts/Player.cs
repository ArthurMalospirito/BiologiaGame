using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5;
    private void Update()
    {
        transform.Rotate(new Vector3(0,0,speed));
        
    }
}
