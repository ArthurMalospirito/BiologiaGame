
using System.Collections;
using UnityEngine;

public class ChildMenu : MonoBehaviour
{
    public GeneticController child;
    private Player player;

    private ChildMenuController childMenuController;
    [SerializeField] private Black black;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        childMenuController = GetComponentInParent<ChildMenuController>();
    }

    public void OnYes()
    {
        StartCoroutine(YesCoroutine(2f));
    }
    private IEnumerator YesCoroutine(float blackDuration)
    {
        //Deixa tela preta
        black.ShowBlack(blackDuration*0.8f);
        //Para o player
        var playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.canMove=false;

        //Espera
        yield return new WaitForSeconds(blackDuration);
        //Passa dados do filho pro player
        var playerGeneticController = player.GetComponent<GeneticController>();
        playerGeneticController.genes=child.genes;
        playerGeneticController.ApplyTraits();
        
        //Coloca eles no mesmo local
        player.transform.position = child.transform.position;
        //Delete ovo se tem antes de deletar o filho
        var egg = child.GetComponentInParent<EggController>();
        if (egg != null)
        {
            Destroy(egg.gameObject);
        }
        //Deleta o filho
        Destroy(child.gameObject);

        //Adicionando vida e água
        var playerResourceController = player.GetComponent<ResourceController>();
        if (playerResourceController!=null)
        {
            playerResourceController.AddFood(1000);
            playerResourceController.AddWater(1000);
        }
        var playerHealthController = player.GetComponent<HealthController>();
        if (playerHealthController!=null)
        {
            playerHealthController.AddHealth(1000);
        }

        //Libera o player
        playerMovement.canMove=true;
        //Volta tela pro normal
        black.HideBlack(blackDuration*0.5f);

        childMenuController.CloseChildMenu();
    }
    public void OnNo()
    {
        //Fecha o menu
        childMenuController.CloseChildMenu();
    }

}