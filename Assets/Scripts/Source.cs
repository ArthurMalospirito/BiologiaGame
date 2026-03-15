
using UnityEngine;

public class Source : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SourceSpawn sourceSpawn;
    [SerializeField] private float distanceToActivate =10;

    private Camera cam;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sourceSpawn = GetComponent<SourceSpawn>();
        cam = Camera.main;
    }

    private void Update()
    {
        VerifyDistance();
    }

    private void VerifyDistance()
    {
        float distanceToCamera = Vector2.Distance(transform.position, cam.transform.position);

        if (distanceToCamera<=distanceToActivate)
        {
            spriteRenderer.enabled=true;
            sourceSpawn.enabled=true;
        } else
        {
            spriteRenderer.enabled=false;
            sourceSpawn.enabled=false;
        }
    }

}
