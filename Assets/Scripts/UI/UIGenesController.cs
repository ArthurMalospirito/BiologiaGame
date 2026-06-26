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
    [SerializeField] private TMP_Dropdown dropdownBeak;
    [SerializeField] private TMP_Dropdown dropdownWing;

    public bool dropdownsActive=false;

    private List<TMP_Dropdown> dropdownList = new List<TMP_Dropdown>();

    private void Start()
    {
        dropdownList.Add(dropdownColor);
        dropdownList.Add(dropdownTail);
        dropdownList.Add(dropdownBeak);
        dropdownList.Add(dropdownWing);

        SetGenesInUI();
        SetDropdownsActive(dropdownsActive);
    }

    private void OnEnable()
    {
        SetGenesInUI();
        SetDropdownsActive(dropdownsActive);
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
                case Traits.beak:
                    SetDropdown(dropdownBeak,gene);
                    break;
                case Traits.wing:
                    SetDropdown(dropdownWing,gene);
                    break;
                default:
                    Debug.LogError("ERRO AO INSERIR GENES NA UI");
                    break;
            }
        }
    }

    private void SetDropdown(TMP_Dropdown dropdown, Gene gene)
    {
        dropdown.value = gene.Genotype switch
        {
            Genotypes.HomoDominant => 0,
            Genotypes.Hetero => 1,
            Genotypes.HomoRecessive => 2,
            _ => 1
        };
    }

    public void SetDropdownsActive(bool state)
    {
        dropdownsActive=state;
        foreach(var dropdown in dropdownList)
        {
            dropdown.interactable=dropdownsActive;
        }
    }


}
