
using UnityEngine;

public class Source : MonoBehaviour
{
    private SourceSpawn sourceSpawn;
    [SerializeField] private float distanceToActivate =10;

    private Camera cam;


    private void Awake()
    {
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
            sourceSpawn.enabled=true;
        } else
        {
            sourceSpawn.enabled=false;
        }
    }

}
