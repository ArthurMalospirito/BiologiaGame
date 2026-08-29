using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float targetAspect = 16f / 9f;
    [SerializeField] private int targetWidth = 1920;
    [SerializeField] private int targetHeight = 1080;

    private void Start()
    {
        Screen.SetResolution(targetWidth, targetHeight, FullScreenMode.Windowed);
        StartCoroutine(EnforceNextFrame());
    }

    private IEnumerator EnforceNextFrame()
    {
        yield return null; // espera a resolução ser aplicada
        EnforceAspect();
    }

    private void EnforceAspect()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera cam = GetComponent<Camera>();

        if (scaleHeight < 1f)
        {
            // barras em cima e embaixo (letterbox)
            Rect rect = cam.rect;
            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0f;
            rect.y = (1f - scaleHeight) / 2f;
            cam.rect = rect;
        }
        else
        {
            // barras nas laterais (pillarbox)
            float scaleWidth = 1f / scaleHeight;
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0f;
            cam.rect = rect;
        }
    }
}
