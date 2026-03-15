
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed=5;
    private Vector2 direction;
    private bool CanMove;
    public float dragForce =2.5f;

    public enum MovementType
    {
        SeekMouse,
        EightDirection
    }
    public MovementType currentMovementType = MovementType.SeekMouse;

    private Rigidbody2D rb;
    private Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = dragForce;
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        Move();
    }



    private void Move()
    {
        switch (currentMovementType)
        {
            case MovementType.SeekMouse:
                SeekMouseMove();

            break;

            case MovementType.EightDirection:
                EightDirectionMove();
            break;

            default:

            break;
        }
        LookDirection();

    }
    private void LookDirection()
    {
        if (direction.sqrMagnitude > 0.01f)
        {
            float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0,0,rotationAngle);
        }
    }

#region SeekMovement

    public void OnClickMove(InputAction.CallbackContext context)
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

    private void SeekMouseMove()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = cam.ScreenToWorldPoint(mouseScreen);
        
        direction = (Vector2)(mouseWorld - transform.position);
        direction.Normalize();
        if (CanMove)
        {
            rb.linearVelocity = speed * direction;
        }

    }

#endregion

#region  EightDirectionMovement

    public void OnMovement(InputAction.CallbackContext callbackContext)
    {
        direction = callbackContext.ReadValue<Vector2>();
    }

    private void EightDirectionMove()
    {
        direction.Normalize();
        rb.linearVelocity = direction*speed;
    }

#endregion

#region 


#endregion
}
