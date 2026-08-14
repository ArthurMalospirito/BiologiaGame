
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneTherapyController : MonoBehaviour
{
    public int geneTherapyUses =0;

    [SerializeField] private TMP_Text geneTherapyNumberText;

    [SerializeField] private Button geneTherapyButton;
    [SerializeField] private GeneTherapyUpgrade geneTherapyUpgrade;

    private void OnEnable()
    {
        SetGeneTherapyUses(geneTherapyUses);
    }

    public void OnClick()
    {
        geneTherapyUpgrade.gameObject.SetActive(true);
        SetGeneTherapyUses(geneTherapyUses-1);
    }

    public void SetGeneTherapyUses(int uses)
    {
        geneTherapyUses = uses;
        geneTherapyNumberText.text= Convert.ToString(geneTherapyUses) + "x";

        geneTherapyButton.interactable=geneTherapyUses>0;
    }

    private void AddUse()
    {
        SetGeneTherapyUses(geneTherapyUses+1);
    }
}
