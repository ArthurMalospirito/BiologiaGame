
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed=5;

    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SeekMouse();
        
    }

    private void SeekMouse()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        
        Vector2 directionToPoint = mouseWorld - transform.position;
        directionToPoint.Normalize();
        float rotationAngle = (Mathf.Atan2(directionToPoint.y,directionToPoint.x) * Mathf.Rad2Deg)-90;
        transform.rotation = Quaternion.Euler(0,0,rotationAngle);
    }
}
