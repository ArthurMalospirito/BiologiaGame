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
    private float initialBarWidth;
    private float barWidth;
    private float initialBarHeight;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialBarWidth=rectTransform.sizeDelta.x;
        barWidth=initialBarWidth;
        initialBarHeight=rectTransform.sizeDelta.y;
    }
    /// <summary>
    /// Função que aumenta tamanho da barra de UI
    /// </summary>
    /// <param name="resizeFactor">Valor de 0,1 = +10% de barra</param>
    public void GrowBar(float resizeFactor,bool totalBar)
    {
        if (totalBar)
        {
            barWidth*=resizeFactor;
        } else
        {  
            barWidth+=initialBarWidth*resizeFactor;
        }
        rectTransform.sizeDelta=new Vector2(barWidth,initialBarHeight);
    }
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
