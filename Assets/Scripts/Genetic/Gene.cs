using UnityEngine;
using System.Collections.Generic;
using Enums.Traits;
using Enums.Genotypes;

/// <summary>
/// Representa uma característica específica de um indivíduo, contento qual característica ele representa, o genótipo do indivíduo e os alelos que formam tal genótipo.
/// </summary>
[System.Serializable]
public class Gene
{
    /// <summary>
    /// Enum que define qual tipo de caracterísca esse Gene irá definir.
    /// </summary>
    public Traits traitType;
    /// <summary>
    /// Enum que define o genótipo de tal característica.
    /// </summary>
    public Genotypes genotype;
    /// <summary>
    /// Composição de Alelos que foram o genótipo.
    /// </summary>
    public string[] AllelesArray {get;private set;}

    public Gene(Traits TraitType, Genotypes genotype)
    {
        traitType = TraitType;
        AllelesArray = new string[2];
        this.genotype = genotype;
        UpdateAlleles();
    }

    public void OnValidate()    
    {
        UpdateAlleles();
    }
    /// <summary>
    /// Função de inserir os alelos automaticamente baseado no genotype.
    /// </summary>
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
    /// <summary>
    /// Função de cruzar dois Genes específicos a fim de criar um terceiro escolhido de forma aleatória, contendo 50% das características de um e 50% das caracteríscas de outro.
    /// </summary>
    /// <param name="gene1">Primeiro gene que será herdado as características</param>
    /// <param name="gene2">Segundo gene que será herdado as características</param>
    /// <returns>Novo Gene feito do cruzamento dos dois genes inseridos.</returns>
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
    /// <summary>
    /// Função de cruzar listas completas de Genes, a fim de criar um novo conjunto de genes cruzados.
    /// </summary>
    /// <param name="genes1">Primeira lista de Genes</param>
    /// <param name="genes2">Segunda lista de Genes</param>
    /// <returns>Nova lista com genes cruzados</returns>
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
