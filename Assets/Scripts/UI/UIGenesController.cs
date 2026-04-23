using System.Collections.Generic;
using Enums.Genotypes;
using Enums.Traits;
using TMPro;
using UnityEngine;

public class UIGenesController : MonoBehaviour
{
    [SerializeField] private GeneticController geneticController;
    [SerializeField] private TMP_Dropdown dropdownColor;
    [SerializeField] private TMP_Dropdown dropdownTail;

    public bool dropdownsActive=false;

    private List<TMP_Dropdown> dropdownList = new List<TMP_Dropdown>();

    private void Start()
    {
        dropdownList.Add(dropdownColor);
        dropdownList.Add(dropdownTail);

        SetGenesInUI();
        SetDropdownActive(dropdownsActive);
    }

    private void OnEnable()
    {
        SetGenesInUI();
        SetDropdownActive(dropdownsActive);
    }

    public void SetGenesInUI()
    {
        foreach(var gene in geneticController.genes)
        {
            switch (gene.traitType) {
                case Traits.color:
                    SetDropdown(dropdownColor,gene);
                    break;
                case Traits.tail:
                    SetDropdown(dropdownTail,gene);
                    break;
                default:
                    Debug.LogError("ERRO AO INSERIR GENES NA UI");
                    break;
            }
        }
    }

    private void SetDropdown(TMP_Dropdown dropdown, Gene gene)
    {
        dropdown.value = gene.genotype switch
        {
            Genotypes.HomoDominant => 0,
            Genotypes.Hetero => 1,
            Genotypes.HomoRecessive => 2,
            _ => 1
        };
    }

    public void SetDropdownActive(bool state)
    {
        dropdownsActive=state;
        foreach(var dropdown in dropdownList)
        {
            dropdown.interactable=dropdownsActive;
        }
    }


}
