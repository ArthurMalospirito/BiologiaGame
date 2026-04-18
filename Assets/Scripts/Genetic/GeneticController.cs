using System.Collections.Generic;
using UnityEngine;

public class GeneticController : MonoBehaviour
{

    [SerializeField] private bool hasParents;
    [SerializeField] private GeneticController parent1;
    [SerializeField] private GeneticController parent2;
    public List<Gene> genes = new List<Gene>();
    private List<Trait> TraitsList;

    [SerializeField] private TraitList TraitList;

    public void Awake()
    {
        TraitsList = TraitList.TraitsList;
        if (hasParents==false)
            return;
        
        genes = Gene.CrossGenesList(parent1.genes,parent2.genes);
    }

    public void Start()
    {
        ApplyTraits(); 
    }

    public void OnEnable()
    {
        ReloadTraits();
    }

    public void ApplyTraits()
    {
        foreach(var trait in TraitsList)
        {
            Gene gene = genes.Find(x => x.traitType==trait.traitType);
            if (gene==null) 
                continue;
            
            trait.Apply(gameObject,gene);
        }
    }

    public void ReloadTraits()
    {
        if (hasParents)
        {
            genes = Gene.CrossGenesList(parent1.genes,parent2.genes);
        }

        ApplyTraits();
    }
}
