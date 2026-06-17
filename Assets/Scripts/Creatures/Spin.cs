using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float spinSpeed =180f;
    private bool spining=false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if(!spining) return;

        rb.rotation += spinSpeed*Time.fixedDeltaTime;    
    }

    public void SetSpin(bool value)
    {
        int random = Random.Range(-1,2);
        if (random==0) random=-1;
        spinSpeed*= random;
        spining=value;
    }

}
