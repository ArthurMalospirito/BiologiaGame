using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMenuController : MonoBehaviour
{
    [SerializeField]private Button buttonGenes;
    [SerializeField]private GameObject genesContent;
    [SerializeField]private Button buttonBiotech;
    [SerializeField]private GameObject biotechContent;
    [SerializeField]private Button buttonConfig;
    [SerializeField]private GameObject configContent;

    private List<Button> ButtonList = new List<Button>();
    private List<GameObject> ContentList = new List<GameObject>();

    private void Awake()
    {
        ContentList.Add(genesContent);
        ContentList.Add(biotechContent);
        ContentList.Add(configContent);

        ButtonList.Add(buttonGenes);
        ButtonList.Add(buttonBiotech);
        ButtonList.Add(buttonConfig);
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

    private void ResetMenu()
    {
        foreach(var content in ContentList)
        {
            content.SetActive(false);
        }
    }
        
        
}
