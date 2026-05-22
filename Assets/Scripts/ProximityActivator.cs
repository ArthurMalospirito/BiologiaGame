
using UnityEngine;

public class ProximityActivator : MonoBehaviour
{
    [SerializeField] private float activeRadius = 20f;
    [SerializeField] private MonoBehaviour targetComponent;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        targetComponent.enabled = distance <= activeRadius;
    }
}