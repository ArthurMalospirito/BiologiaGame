

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
    public static bool canProcreate=true;
    public static int procreateCooldown=0;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        rightMenuController = GetComponentInParent<RightMenuController>();
        childMenuController = GetComponentInParent<ChildMenuController>();
    }

    private void OnEnable()
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
        if (status==true)
        {
            procreateButton.interactable=true;
        } else
        {
            procreateButton.interactable=false;
        }
    }

}