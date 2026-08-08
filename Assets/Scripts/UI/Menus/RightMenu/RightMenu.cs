

using UnityEngine;

public class RightMenu : MonoBehaviour
{
    public Transform transformLocation;
    public GeneticController targetGeneticController;
    public Creature targetCreature;
    private Player player;
    private RightMenuController rightMenuController;
    [SerializeField] private EggController eggPrefab;
    [SerializeField] private ChildMenuController childMenuController;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        rightMenuController = GetComponentInParent<RightMenuController>();
        childMenuController = GetComponentInParent<ChildMenuController>();
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

        childMenuController.SetChild(childGeneticController);
        childMenuController.OpenChildMenu();

        rightMenuController.CloseRightMenu();
    }
}