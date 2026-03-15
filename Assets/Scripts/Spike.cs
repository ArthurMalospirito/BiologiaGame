using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    public int damage = 10;

    public float stunTime = 1.5f;

    public float pushForce =5;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {            
            HealthController healthController = other.GetComponent<HealthController>();
            if (healthController!=null)
                healthController.Damage(damage);
            else 
                Debug.Log("Não tem healthController");
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement!=null)
            {
                Vector2 force = (Vector2)(other.transform.position - transform.position).normalized;

                playerMovement.Stun(stunTime);
                playerMovement.AddForce(force*pushForce);
                
            } else
            {
                Debug.Log("Não tem playerMovement");
            }
            
        }
    }
}
