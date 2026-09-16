using UnityEngine;

public class SecretDamage : MonoBehaviour
{
    public void OnDamage()
    {
        if (DialogController.TryDialogTrigger(Enums.DialogueTrigger.DialogTrigger.SecretDialog))
            DarwinMenuController.Instance.OpenMenu(Enums.DialogueTrigger.DialogTrigger.SecretDialog);
        
        //Apenas um tapa buraco para quando não iniciou nenhum
        if (TransgenicController.Instance==null || GeneTherapyController.Instance==null || AntibioticController.Instance==null) return;

        for (int i=0;i<100;i++)
        {
            TransgenicController.Instance.AddUse();
            GeneTherapyController.Instance.AddUse();
            AntibioticController.Instance.AddUse();
        }

    }
}
