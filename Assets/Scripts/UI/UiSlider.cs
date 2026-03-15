using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    public bool hasText;
    [SerializeField] TMP_Text text;
    public string textType;

    public void SetFill(float amount, float totalAmount)
    {
        slider.value=amount/totalAmount;

        if (slider.value<=0)
        {
            fill.enabled=false;
        } else
        {
            fill.enabled=true;
        }

        if (hasText)
        {
            text.text = $"{amount}/{totalAmount} {textType}";
        }
    }
}
