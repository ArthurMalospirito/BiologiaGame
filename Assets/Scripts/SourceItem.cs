using UnityEngine;

public class SourceItem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float drag = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = drag;
    }

    public void AddForce(Vector2 pushForce)
    {
        rb.AddForce(pushForce);
    }
}
