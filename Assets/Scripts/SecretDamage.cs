using UnityEngine;

public class SecretDamage : MonoBehaviour
{
    public void OnDamage()
    {
        if (DialogController.TryDialogTrigger(Enums.DialogueTrigger.DialogTrigger.SecretDialog))
            DarwinMenuController.Instance.OpenMenu(Enums.DialogueTrigger.DialogTrigger.SecretDialog);
        for (int i=0;i<100;i++)
        {
            TransgenicController.Instance.AddUse();
            GeneTherapyController.Instance.AddUse();
            AntibioticController.Instance.AddUse();
        }

    }
}
