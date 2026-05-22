using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransgenicController : MonoBehaviour
{

    [SerializeField] TabMenuController tabMenuController;

    public int transgenicUses =1;

    [SerializeField] private TMP_Text transgenicNumberText;

    [SerializeField] private UIGenesController uiGenesController;

    [SerializeField] private Button transgenicButton;

    private void OnEnable()
    {
        SetTransgenicUses(transgenicUses);
    }

    //Fazer alguma verificação para não gastar todos de uma vez.
    public void AllowTransgenicSwap()
    {
        if (transgenicUses>0)
        {  
            tabMenuController.OpenGenes();
            uiGenesController.SetDropdownsActive(true);
            SetTransgenicUses(transgenicUses-1);
        } else
        {
            //Colocar um PopUp, algum aviso que diz que nn tem usos.
            Debug.Log("Sem usos de trangênicos! (Vc deveria mudar isso)");
        }

    }

    public void SetTransgenicUses(int uses)
    {
        transgenicUses = uses;
        transgenicNumberText.text= Convert.ToString(transgenicUses) + "x";

        transgenicButton.interactable=transgenicUses>0;
    }
}
