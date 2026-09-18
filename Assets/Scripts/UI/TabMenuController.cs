using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMenuController : MonoBehaviour
{
    [Header("Genes")]
    [SerializeField]private Button buttonGenes;
    [SerializeField]private GameObject genesContent;
    [Header("Biotech")]
    [SerializeField]private Button buttonBiotech;
    [SerializeField]private GameObject biotechContent;
    [Header("Config")]
    [SerializeField]private Button buttonConfig;
    [SerializeField]private GameObject configContent;
    [Header("GeneticInfo")]
    [SerializeField] private Button buttonGeneticInfo;
    [SerializeField] private GameObject geneticInfoContent;
    [Header("BiotechInfo")]
    [SerializeField] private Button buttonBiotechInfo;
    [SerializeField] private GameObject biotechInfoContent;
    [Header("EvolutionInfo")]
    [SerializeField] private Button buttonEvolutionInfo;
    [SerializeField] private GameObject evolutionInfoContent;

    private List<Button> ButtonList = new List<Button>();
    private List<GameObject> ContentList = new List<GameObject>();

    private void Awake()
    {
        ContentList.Add(genesContent);
        ContentList.Add(biotechContent);
        ContentList.Add(configContent);
        ContentList.Add(geneticInfoContent);
        ContentList.Add(biotechInfoContent);
        ContentList.Add(evolutionInfoContent);

        ButtonList.Add(buttonGenes);
        ButtonList.Add(buttonBiotech);
        ButtonList.Add(buttonConfig);
        ButtonList.Add(buttonGeneticInfo);
        ButtonList.Add(buttonBiotechInfo);
        ButtonList.Add(buttonEvolutionInfo);
    }

    private void Start()
    {
        OpenBiotech();
    }

    public void OpenGenes()
    {
        ResetMenu();
        genesContent.SetActive(true);
    }

    public void OpenBiotech()
    {
        ResetMenu();
        biotechContent.SetActive(true);
    }

    public void OpenConfig()
    {
        ResetMenu();
        configContent.SetActive(true);
    }
    public void OpenGeneticInfo()
    {
        ResetMenu();
        geneticInfoContent.SetActive(true);
    }
    public void OpenBiotechInfo()
    {
        ResetMenu();
        biotechInfoContent.SetActive(true);
    }
    public void OpenEvolutionInfo()
    {
        ResetMenu();
        evolutionInfoContent.SetActive(true);
    }

    private void ResetMenu()
    {
        foreach(var content in ContentList)
        {
            content.SetActive(false);
        }
    }
        
        
}
