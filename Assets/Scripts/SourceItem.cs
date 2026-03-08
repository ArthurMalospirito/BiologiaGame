using System;
using UnityEngine;

public class SourceItem : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float drag = 1;
    [SerializeField] private string resourceType;
    [SerializeField] private float resourceAmount=1;

    [SerializeField] private string targetTag = "Player";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = drag;
    }

    public void AddForce(Vector2 pushForce)
    {
        rb.AddForce(pushForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag))
        {
            return;
        }

        ResourceController resourceController = other.GetComponent<ResourceController>();

        if (resourceController!=null)
        {
            switch (resourceType)
            {
                case "xp":
                    resourceController.addXp(Convert.ToInt32(resourceAmount));
                break;
                case "food":
                    resourceController.addFood(resourceAmount);
                break;
                case "water":
                    resourceController.addWater(resourceAmount);
                break;
                default:
                    Debug.LogError("Erro ao enviar definir tipo do recurso");
                break;

            }
            Destroy(gameObject);
        }
    }
}