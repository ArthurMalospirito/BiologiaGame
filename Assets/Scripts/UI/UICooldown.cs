

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICooldown : MonoBehaviour
{
    [SerializeField] private Image imageSimbol;
    [SerializeField] private Image imageCircle;

    private void setFill(float amount)
    {
        imageCircle.fillAmount=amount;
    }

    public void setInCooldown(float seconds)
    {
        StartCoroutine(setFillCoroutine(seconds));
    }

    private IEnumerator setFillCoroutine(float seconds)
    {
        float elapsed =0f;
        Color fadeColor = imageSimbol.color;
        fadeColor.a=0.5f;
        imageSimbol.color = fadeColor;

        while (elapsed<seconds)
        {
            elapsed+=Time.deltaTime;
            setFill(elapsed/seconds);
            yield return null; 
        }
        setFill(0);
        Color originalColor = imageSimbol.color;
        originalColor.a = 1f;
        imageSimbol.color=originalColor;

    }
}