
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 Direction {get; private set;}

    public float normalSpeed = 4;
    public float Speed{get;set;}
    public bool CanMove {get;private set;} = true;
    private bool isMoving;

    public float dragForce=5f;

    public enum MovementType
    {
        SeekMouse,
        EightDirection
    }
    public MovementType currentMovementType = MovementType.SeekMouse;

    private Rigidbody2D rb;
    private Camera cam;

    public string dontMoveTag = "Menu";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = dragForce;
        cam = Camera.main;
        Speed=normalSpeed;
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

    private bool IsMouseOverTag(string targetTag)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData,results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag(targetTag)) return true;
        }
        return false;
    }

#region SeekMovement

    public void OnClickMove(InputAction.CallbackContext context)
    {
        if (IsMouseOverTag(dontMoveTag)) return;
        
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
            rb.linearVelocity = Speed * Direction;
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
        rb.linearVelocity = Direction*Speed;

    }

#endregion

}
