
using UnityEngine;

public class ProximityActivator : MonoBehaviour
{
    [SerializeField] private ResourceData resourceData;
    private float activateRadius;
    [SerializeField] private MonoBehaviour targetComponent;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        activateRadius = resourceData.ActivateRadius;
    }
    private void Update()
    {
        if (player==null) return;
        float distance = Vector2.Distance(transform.position, player.position);
        targetComponent.enabled = distance <= activateRadius;
    }
}