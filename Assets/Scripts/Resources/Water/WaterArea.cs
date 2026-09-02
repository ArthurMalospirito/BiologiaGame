using System.Collections;
using UnityEngine;

public class WaterArea : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private float waterPerTick=0.05f;
    [SerializeField] private float tickTime =0.01f;
    private Coroutine drinkWater;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;
        ResourceController resourceController = other.GetComponent<ResourceController>();
        if (resourceController==null)
        {
            Debug.LogError("Sem resource movement no player");
            return;
        }
        drinkWater = StartCoroutine(DrinkWaterCoroutine(resourceController));
        if (DialogController.TryDialogTrigger(Enums.DialogueTrigger.DialogTrigger.FirstWater))
            DarwinMenuController.Instance.OpenMenu(Enums.DialogueTrigger.DialogTrigger.FirstWater);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;
        StopCoroutine(drinkWater);
    }

    private IEnumerator DrinkWaterCoroutine(ResourceController resourceController)
    {
        while (true)
        {
            yield return new WaitForSeconds(tickTime);
            resourceController.AddWater(waterPerTick);
        }   
            
    }
}
