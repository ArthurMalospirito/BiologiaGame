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
    [SerializeField] private Button buttonGenetic;
    [SerializeField] private GameObject geneticContent;

    private List<Button> ButtonList = new List<Button>();
    private List<GameObject> ContentList = new List<GameObject>();

    private void Awake()
    {
        ContentList.Add(genesContent);
        ContentList.Add(biotechContent);
        ContentList.Add(configContent);
        ContentList.Add(geneticContent);

        ButtonList.Add(buttonGenes);
        ButtonList.Add(buttonBiotech);
        ButtonList.Add(buttonConfig);
        ButtonList.Add(buttonGenetic);
    }

    private void Start()
    {
        OpenGenes();
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
    public void OpenGenetic()
    {
        ResetMenu();
        geneticContent.SetActive(true);
    }

    private void ResetMenu()
    {
        foreach(var content in ContentList)
        {
            content.SetActive(false);
        }
    }
        
        
}
