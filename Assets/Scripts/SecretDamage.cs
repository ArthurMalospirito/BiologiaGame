using UnityEngine;

public class SecretDamage : MonoBehaviour
{
    [SerializeField] private TransgenicController transgenicController;
    [SerializeField] private GeneTherapyController geneTherapyController;
    [SerializeField] private AntibioticController antibioticController;
    public void OnDamage()
    {
        if (DialogController.TryDialogTrigger(Enums.DialogueTrigger.DialogTrigger.SecretDialog))
            DarwinMenuController.Instance.OpenMenu(Enums.DialogueTrigger.DialogTrigger.SecretDialog);
        for (int i=0;i<100;i++)
        {
            transgenicController.AddUse();
            geneTherapyController.AddUse();
            antibioticController.AddUse();
        }

    }
}
