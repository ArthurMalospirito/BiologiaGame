using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed=5;
    [SerializeField] private float arrivalThreshold = 0.2f;
    private Vector2 destination;
    private bool isMoving=false;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;
        if (HasArrived())
        {
            isMoving=false;
            rb.linearVelocity=Vector2.zero;
            return;
        }
        Vector2 direction = destination - rb.position;

        if (direction.sqrMagnitude>0.01f)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg+90;
            float smoothAngle = Mathf.LerpAngle(rb.rotation,angle,0.3f);
            rb.rotation = smoothAngle;

            float distance = direction.magnitude;
            float currentSpeed = Mathf.Min(speed,distance/Time.fixedDeltaTime);
            rb.linearVelocity=direction.normalized*currentSpeed;
        }

    }

    public void MoveTo(Vector2 location) 
    {
        destination=location;
        isMoving=true;
    }

    private bool HasArrived()
    {
        return Vector2.Distance(rb.position, destination) < arrivalThreshold;
    }
}
