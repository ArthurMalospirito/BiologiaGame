

using System.Collections.Generic;
using Enums.DialogueTrigger;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    private static Dictionary<DialogTrigger, bool> triggered = new Dictionary<DialogTrigger, bool>();
    public static bool alreadyReset=false;

    private void Awake()
    {
        ResetAllDialogs();
    }
    public static bool TryDialogTrigger(DialogTrigger trigger)
    {
        if (triggered[trigger]) return false;
        triggered[trigger] = true;
        return true;
    }
    public static bool VerifyDialogTrigger(DialogTrigger trigger)
    {
        return triggered[trigger];
    }
    public static void SetDialogTrigger(DialogTrigger trigger,bool value)
    {
        triggered[trigger] = value;
    }
    private void ResetAllDialogs()
    {
        if (alreadyReset) return;
        foreach (DialogTrigger trigger in System.Enum.GetValues(typeof(DialogTrigger)))
        {
            triggered[trigger] = false;
        }
        alreadyReset=true;
    }
}
