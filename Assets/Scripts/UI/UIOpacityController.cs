
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIOpacityController : MonoBehaviour
{
    private Image image;
    [Range(0f,1f)][SerializeField]private float normalOpacity=0f;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        Color color = image.color;
        color.a=normalOpacity;
        image.color=color;
    }

    public void FadeOpacity(float targetOpacity, float duration)
    {
        StartCoroutine(FadeOpacityCoroutine(targetOpacity,duration));
    }

    private IEnumerator FadeOpacityCoroutine(float targetOpacity, float duration)
    {
        float startOpacity = image.color.a;
        float elapsed =0f;

        while (elapsed<duration)
        {
            elapsed+=Time.deltaTime;
            float t = elapsed/duration;

            Color c = image.color;
            c.a = Mathf.Lerp(startOpacity, targetOpacity,t);
            image.color=c;

            yield return null;
        }

        Color finalColor = image.color;
        finalColor.a = targetOpacity;
        image.color=finalColor;
    }


}
