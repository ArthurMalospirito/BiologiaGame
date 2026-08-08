
using System.Collections;
using UnityEngine;

public class ClearOnUnder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private string targetTag = "Player";
    [Range(0f,1f)][SerializeField]private float normalOpacity=0.8f;
    [Range(0f,1f)][SerializeField] private float targetOpacity=0.3f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void Start()
    {
        Color color = spriteRenderer.color;
        color.a=normalOpacity;
        spriteRenderer.color=color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;
        StartCoroutine(FadeOpacity(targetOpacity,0.3f));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;
        StartCoroutine(FadeOpacity(normalOpacity,0.3f));
    }

    private IEnumerator FadeOpacity(float targetOpacity, float duration)
    {
        float startOpacity = spriteRenderer.color.a;
        float elapsed =0f;

        while (elapsed<duration)
        {
            elapsed+=Time.deltaTime;
            float t = elapsed/duration;

            Color c = spriteRenderer.color;
            c.a = Mathf.Lerp(startOpacity, targetOpacity,t);
            spriteRenderer.color=c;

            yield return null;
        }

        Color finalColor = spriteRenderer.color;
        finalColor.a = targetOpacity;
        spriteRenderer.color=finalColor;
    }


}
