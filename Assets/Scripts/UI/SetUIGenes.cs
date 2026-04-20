using Enums.Genotypes;
using Enums.Traits;
using TMPro;
using UnityEngine;

public class SetUIGenes : MonoBehaviour
{
    [SerializeField] private GeneticController geneticController;

    [SerializeField] private TMP_Dropdown dropdownColor;
    [SerializeField] private TMP_Dropdown dropdownTail;

    public void Start()
    {
        SetGenesInUI();
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


}
