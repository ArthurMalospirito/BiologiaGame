using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AntibioticController : MonoBehaviour
{
    public static AntibioticController Instance;

    public int antiobioticUses =0;

    [SerializeField] private TMP_Text antiobioticNumberText;

    [SerializeField] private Button antibioticButton;
    private Player player;
    private DiseaseController diseaseController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        diseaseController=player.GetComponent<DiseaseController>();
    }
    private void OnEnable()
    {
        SetAntibioticUses(antiobioticUses);
    }

    public void OnClick()
    {
        SetAntibioticUses(antiobioticUses-1);
        PlayerStatsManager.Instance.totalBiotechUses++;
        diseaseController.DesactiveDisease();
    }

    public void SetAntibioticUses(int uses)
    {
        antiobioticUses = uses;
        antiobioticNumberText.text= Convert.ToString(antiobioticUses) + "x";

        antibioticButton.interactable=antiobioticUses>0;
    }

    public void AddUse()
    {
        SetAntibioticUses(antiobioticUses+1);
    }
}
