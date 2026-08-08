
using System.Collections;
using UnityEngine;

public class Black : MonoBehaviour
{
    private UIOpacityController blackUIOpacityController;

    private void Start()
    {
        blackUIOpacityController = GetComponentInChildren<UIOpacityController>(true);
    }

    public void ShowBlack(float duration)
    {
        blackUIOpacityController.gameObject.SetActive(true);
        blackUIOpacityController.FadeOpacity(1,duration);
    }
    public void HideBlack(float duration)
    {
        StartCoroutine(HideBlackCoroutine(duration));
    }
    private IEnumerator HideBlackCoroutine(float duration)
    {
        blackUIOpacityController.FadeOpacity(0,duration);
        yield return new WaitForSeconds(duration*1.1f);
        blackUIOpacityController.gameObject.SetActive(false);
    }
}