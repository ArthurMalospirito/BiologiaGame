using Enums.Traits;
using UnityEngine;

public class Nest : MonoBehaviour
{
    [SerializeField] private int amountCreatures=3;
    [SerializeField] private Creature creature;
    [SerializeField] private Traits[] unaffectedTraits=null;
    

    private void Start()
    {
        for(int i=0;i<amountCreatures;i++)
        {
            SpawnCreature();
        }
    }
    private void SpawnCreature()
    {
        var newCreature = Instantiate(creature,transform.position,Quaternion.identity);
        newCreature.transform.SetParent(gameObject.transform);
        newCreature.nest=this;
        var newGeneticController = newCreature.GetComponent<GeneticController>();
        if (newGeneticController==null)
        {
            Debug.Log("Sem Genetic controller para aleatorizar");
            return;
        }
        newGeneticController.RandomizeGenes(unaffectedTraits);
    }
}
