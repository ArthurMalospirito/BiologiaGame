

using UnityEngine;

public class RightMenu : MonoBehaviour
{
    public Transform transformLocation;
    public GeneticController geneticController;
    private Player player;
    private RightMenuController rightMenuController;
    [SerializeField] private EggController eggPrefab;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        rightMenuController = GetComponentInParent<RightMenuController>();
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
        childGeneticController.parent2=geneticController;
        childGeneticController.hasParents=true;

        rightMenuController.CloseRightMenu();
    }
}