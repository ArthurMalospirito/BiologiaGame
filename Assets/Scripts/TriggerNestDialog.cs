using UnityEngine;

public class TriggerNestDialog : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
            return;
        if (DialogController.TryDialogTrigger(Enums.DialogueTrigger.DialogTrigger.FirstNest))
            DarwinMenuController.Instance.OpenMenu(Enums.DialogueTrigger.DialogTrigger.FirstNest);
    }
}
