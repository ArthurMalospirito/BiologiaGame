using UnityEngine;
using System.Collections.Generic;
using Enums.Traits;
using Enums.Genotypes;

[System.Serializable]
public class Gene
{
    public Traits traitType;
    public string[] AllelesArray {get;private set;}
    public Genotypes genotype;

    public Gene(Traits TraitType, Genotypes genotype)
    {
        this.traitType = TraitType;
        AllelesArray = new string[2];
        this.genotype = genotype;
        UpdateAlleles();
    }

    public void OnValidate()    
    {
        UpdateAlleles();
    }

    private void UpdateAlleles()
    {
        AllelesArray = genotype switch
        {
            Genotypes.HomoDominant => new[] {"A","A"},
            Genotypes.Hetero => new[] {"A","a"},
            Genotypes.HomoRecessive => new[] {"a","a"},
            _ => new[] {"A","a"}
        };
    }
    static public Gene CrossGenes(Gene gene1, Gene gene2)
    {
        gene1.UpdateAlleles();
        gene2.UpdateAlleles();
        if (gene1.traitType==gene2.traitType)
        {
            string newAlleles;
            string allele1 =gene1.AllelesArray[Random.Range(0,2)];
            string allele2 =gene2.AllelesArray[Random.Range(0,2)];
            if (allele2=="A") 
                newAlleles=allele2+allele1;
            else 
                newAlleles=allele1+allele2;

            Genotypes newGenotype = newAlleles switch 
            {
                "AA" => Genotypes.HomoDominant,
                "Aa" => Genotypes.Hetero,
                "aa" => Genotypes.HomoRecessive,
                _ => Genotypes.Hetero
            };

            Gene newGene = new Gene(
                gene1.traitType,
                newGenotype
            );

            return newGene;
        } else
        {
            Debug.LogError("Genes de Traits diferentes!");
            return new Gene(Traits.undefined,Genotypes.Hetero);
        }

    }

    static public List<Gene> CrossGenesList(List<Gene> genes1, List<Gene> genes2)
    {

        List<Gene> newGenes = new List<Gene>();
        
        foreach (var gene1 in genes1)
        {
            Gene gene2 = genes2.Find(x => x.traitType==gene1.traitType);
            if (gene2==null)
                continue;

            newGenes.Add(CrossGenes(gene1,gene2));
        }

        return newGenes;
    }

}
