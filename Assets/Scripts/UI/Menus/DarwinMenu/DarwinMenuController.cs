
using Enums.DialogueTrigger;
using UnityEngine;

public class DarwinMenuController :MonoBehaviour
{
    public static DarwinMenuController Instance {get;private set;}

    [SerializeField] private DialogData[] allDialogs;
    private DarwinMenu darwinMenu;

    private void Awake()
    {
        Instance = this;
        darwinMenu=GetComponentInChildren<DarwinMenu>(true);
    }

    private void Start()
    {
        if (DialogController.TryDialogTrigger(DialogTrigger.Start))
            OpenMenu(DialogTrigger.Start);
    }
    public void OpenMenu(DialogTrigger dialogTrigger)
    {
        DialogData dialog = FindDialog(dialogTrigger);
        if (dialog ==null)
        {
            Debug.LogError("Nenhum diálogo para: " + dialogTrigger);
            return;
        }
        darwinMenu.gameObject.SetActive(true);
        darwinMenu.StartDialog(dialog);
    }
    private DialogData FindDialog(DialogTrigger dialogTrigger)
    {
        foreach(var dialog in allDialogs)
        {
            if (dialog.dialogueTrigger==dialogTrigger) return dialog;
        }
        return null;
    }
}