using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AntibioticController : MonoBehaviour
{
    public int antiobioticUses =0;

    [SerializeField] private TMP_Text antiobioticNumberText;

    [SerializeField] private Button antibioticButton;
    private Player player;
    private DiseaseController diseaseController;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        diseaseController=player.GetComponent<DiseaseController>();
    }
    private void OnEnable()
    {
        SetGeneTherapyUses(antiobioticUses);
    }

    public void OnClick()
    {
        SetGeneTherapyUses(antiobioticUses-1);
        diseaseController.DesactiveDisease();
    }

    public void SetGeneTherapyUses(int uses)
    {
        antiobioticUses = uses;
        antiobioticNumberText.text= Convert.ToString(antiobioticUses) + "x";

        antibioticButton.interactable=antiobioticUses>0;
    }

    public void AddUse()
    {
        SetGeneTherapyUses(antiobioticUses+1);
    }
}
