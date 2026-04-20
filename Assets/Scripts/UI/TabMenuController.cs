using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMenuController : MonoBehaviour
{
    [SerializeField]private Button buttonGenes;
    [SerializeField]private GameObject genesContent;
    [SerializeField]private Button buttonCards;
    [SerializeField]private GameObject cardsContent;

    private List<Button> ButtonList = new List<Button>();
    private List<GameObject> ContentList = new List<GameObject>();

    private void Awake()
    {
        ContentList.Add(genesContent);
        ContentList.Add(cardsContent);

        ButtonList.Add(buttonGenes);
        ButtonList.Add(buttonCards);
    }

    public void OpenGenes()
    {
        ResetMenu();

        genesContent.SetActive(true);
    }

    public void OpenCards()
    {
        ResetMenu();

        cardsContent.SetActive(true);
    }


    private void ResetMenu()
    {
        foreach(var content in ContentList)
        {
            content.SetActive(false);
        }
    }
        
        
}
