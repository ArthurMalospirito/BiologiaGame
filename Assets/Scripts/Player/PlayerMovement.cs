
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed=5;
    public Vector2 Direction {get; private set;}
    public bool isMoving;
    public bool CanMove {get;private set;} = true;
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
        if (!CanMove)
            return;
            
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
        if (Direction.sqrMagnitude > 0.01f)
        {
            float rotationAngle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.Euler(0,0,rotationAngle);
        }
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void Stun(float stunTime)
    {
        CanMove=false;
        StartCoroutine(CanMoveCoroutine(stunTime));
        
    }
    private IEnumerator CanMoveCoroutine(float stunTime)
    {
        
        yield return new WaitForSeconds(stunTime);
        CanMove=true;
    }

#region SeekMovement

    public void OnClickMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isMoving=true;
        }
        if (context.canceled)
        {
            isMoving=false;
        }
    }

    private void SeekMouseMove()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = cam.ScreenToWorldPoint(mouseScreen);
        
        Direction = (Vector2)(mouseWorld - transform.position);
        Direction = Direction.normalized;
        if (isMoving)
        {
            rb.linearVelocity = speed * Direction;
        }

    }

#endregion

#region  EightDirectionMovement

    public void OnMovement(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            isMoving=true;
            Direction = callbackContext.ReadValue<Vector2>();
        } else if(callbackContext.canceled)
        {
            isMoving=false;
        }
        
    }

    private void EightDirectionMove()
    {
        Direction = Direction.normalized;
        rb.linearVelocity = Direction*speed;

    }

#endregion

}
