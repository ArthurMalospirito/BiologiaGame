using Enums.Genotypes;
using Enums.Traits;
using UnityEngine;

public class GenesApplicator : MonoBehaviour
{
    [SerializeField] private GeneticController geneticController;

    private void ApplyGene(Traits traitType, int value)
    {
        Genotypes newGenotype = value switch
        {
            0 => Genotypes.HomoDominant,
            1 => Genotypes.Hetero,
            2 => Genotypes.HomoRecessive,
            _ => Genotypes.Hetero
        };

        Gene gene = geneticController.genes.Find(x => x.traitType==traitType);
        if (gene==null) 
        {
            gene = new Gene(traitType,newGenotype);
            geneticController.genes.Add(gene);
        }
        else
        {
            gene.genotype = newGenotype;
        }
        
        geneticController.ReloadTraits();
    }
    public void ApplyColor(int value)
    {
        ApplyGene(Traits.color,value);
    }

    public void ApplyTail(int value)
    {
        ApplyGene(Traits.tail,value);
    }
}
