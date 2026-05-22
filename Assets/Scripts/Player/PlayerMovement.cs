
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 Direction {get; private set;}

    public float speed=5;
    public bool isMoving;
    public bool CanMove {get;private set;} = true;

    [SerializeField] private float dragForce=5f;
    [SerializeField]private float dashDragMultiplier =0.2f;

    public float dashSpeed=15;
    private bool isDashing;
    public float dashTime =1.5f;
    public float dashCooldown = 1.5f;
    private bool canDash=true;

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
        if (!CanMove || isDashing)
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
        rb.linearVelocity=Vector2.zero;
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

    public void OnDash(InputAction.CallbackContext callbackContext)
    {
        if (!canDash)
            return;
        if (!callbackContext.performed || isDashing)
            return;

        StartCoroutine(DashCoroutine());

    }

    private IEnumerator DashCoroutine()
    {
        isDashing=true;
        CanMove=false;

        rb.linearVelocity=Direction*dashSpeed;
        rb.linearDamping=dragForce*dashDragMultiplier;
        yield return new WaitForSeconds(dashTime);
        StartCoroutine(DashCooldownCoroutine());
        rb.linearDamping=dragForce;
        isDashing=false;
        CanMove=true;
    }

    private IEnumerator DashCooldownCoroutine()
    {
        canDash=false;
        yield return new WaitForSeconds(dashCooldown);
        canDash=true;
    }

#region SeekMovement

    public void OnClickMove(InputAction.CallbackContext context)
    {
        if (currentMovementType!=MovementType.SeekMouse) 
            return;
            
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
        if (currentMovementType!=MovementType.EightDirection)
            return;

        if (callbackContext.performed)
        {
            isMoving=true;
            Direction = callbackContext.ReadValue<Vector2>();
        } else if(callbackContext.canceled)
        {
            isMoving=false;
            Direction = Vector2.zero;
        }
        
    }

    private void EightDirectionMove()
    {
        Direction = Direction.normalized;
        rb.linearVelocity = Direction*speed;

    }

#endregion

}
