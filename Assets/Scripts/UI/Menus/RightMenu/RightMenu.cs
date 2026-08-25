

using System.Linq;
using Enums.Traits;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RightMenu : MonoBehaviour
{
    public Transform transformLocation;
    public GeneticController targetGeneticController;
    public Creature targetCreature;
    private Player player;
    private RightMenuController rightMenuController;
    [SerializeField] private EggController eggPrefab;
    [SerializeField] private ChildMenuController childMenuController;
    [SerializeField] private TMP_Text procreateCooldownText;
    [SerializeField] private Button procreateButton;
    [SerializeField] private TMP_Text sameSexText;
    public static bool canProcreate=true;
    public static int procreateCooldown=0;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        rightMenuController = GetComponentInParent<RightMenuController>();
        childMenuController = GetComponentInParent<ChildMenuController>();
    }

    public void Open()
    {
        SetProcreate(canProcreate);
        SetProcreateCooldown(procreateCooldown);
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(transformLocation.position);
    }
    public void OnProcreate()
    {
        var egg = Instantiate(eggPrefab,player.transform.position,Quaternion.identity);
        var childGeneticController = egg.GetComponentInChildren<GeneticController>(true);

        var playerGenetiController = player.GetComponent<GeneticController>();
        childGeneticController.parent1=playerGenetiController;
        childGeneticController.parent2=targetGeneticController;
        childGeneticController.hasParents=true;

        var childCreature = egg.GetComponentInChildren<Creature>(true);
        childCreature.nest = targetCreature.nest;

        canProcreate=false;
        SetProcreate(false);
        rightMenuController.StartProcreateCooldown();

        childMenuController.SetChild(childGeneticController);
        childMenuController.OpenChildMenu();

        rightMenuController.CloseRightMenu();
    }

    public void SetProcreateCooldown(int value)
    {
        if (value<=0)
        {
            procreateCooldownText.text="";
            return;
        }
        procreateCooldownText.text=value.ToString();
    }

    private void SetProcreate(bool status)
    {
        var targetTailGene = targetGeneticController.genes.FirstOrDefault(gene => gene.traitType==Traits.tail);
        if (targetTailGene==null)
        {
            Debug.LogError("Erro ao encontrar o gene de rabo no Alvo");
        }
        var playerGeneticController = player.GetComponent<GeneticController>();
        if (playerGeneticController==null)
        {
            Debug.LogError("Erro ao encontrar playeGeneticController");
        }
        var playerTailGene = playerGeneticController.genes.FirstOrDefault(gene => gene.traitType==Traits.tail);
        if (playerTailGene == null)
        {
            Debug.LogError("Erro ao encontrar trait de rabo do player");
        }
        bool sameSex =targetTailGene.Genotype==playerTailGene.Genotype;
        if (sameSex)
        {
            procreateButton.interactable=false;
            sameSexText.text="Esse passáro é do mesmo sexo que você.";
            return;
        }
        sameSexText.text="";
        procreateButton.interactable=status;
    }

}