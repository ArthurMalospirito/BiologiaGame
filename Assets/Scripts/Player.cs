
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed=5;
    private Vector2 direction;
    private bool CanMove;
    public float dragForce =1;

    private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = dragForce;
    }
    private void Update()
    {
        SeekMouse();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SeekMouse()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        
        direction = mouseWorld - transform.position;
        direction.Normalize();
        float rotationAngle = (Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg)-90;
        transform.rotation = Quaternion.Euler(0,0,rotationAngle);
    }

    private void Move()
    {
        if (CanMove)
        {
            rb.linearVelocity = speed * direction;
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CanMove=true;
        }
        if (context.canceled)
        {
            CanMove=false;
        }
    }

    private void OnFoodChange(float food)
    {
    }
    private void OnWaterChange(float water)
    {
        
    }
    private void OnXpChange(int xp)
    {
        
    }
}
