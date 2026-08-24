
using Enums.DialogueTrigger;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "Data/DialogData")]
public class DialogData : ScriptableObject
{
    public DialogTrigger dialogueTrigger;
    [TextArea(3,6)] public string[] lines;
}