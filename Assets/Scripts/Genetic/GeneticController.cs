using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Representa uma parte de um objeto que controlará suas características específicas baseado nos Genes definidos.
/// </summary>
public class GeneticController : MonoBehaviour
{
    /// <summary>
    /// Variável que define se o Indivíduo vai ter genes calculados pelo seus pais ou inseridos por outros meios.
    /// </summary>
    public bool hasParents;
    /// <summary>
    /// Definição o primeiro indivíduo que cederá características ao indivíduo filho caso "hasParents" seja True. 
    /// </summary>
    public GeneticController parent1;
    /// <summary>
    /// Definição o segundo indivíduo que cederá características ao indivíduo filho caso "hasParents" seja True. 
    /// </summary>
    public GeneticController parent2;
    /// <summary>
    /// Lista de genes que definiram quais características serão expressas.
    /// </summary>
    public List<Gene> genes = new List<Gene>();
    /// <summary>
    /// Lista de características que os genes podem controlar.
    /// </summary>
    private List<Trait> TraitsList;

    /// <summary>
    /// Campo onde pode ser inserido um TraitList, elemento que armazena várias Traits distintas ao indivíduo.
    /// </summary>
    [SerializeField] private TraitList TraitList;

    /// <summary>
    /// Referencia o elemento que aplica os Genes na UI.
    /// </summary>
    [SerializeField] private UIGenesController UIGenesController;

    public void Awake()
    {
        TraitsList = TraitList.TraitsList;
        if (hasParents==false) return;
        
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

    /// <summary>
    /// Aplica todas as características definidas na lista de Genes.
    /// </summary>
    public void ApplyTraits()
    {
        foreach(var trait in TraitsList)
        {
            Gene gene = genes.Find(x => x.traitType==trait.traitType);
            if (gene==null) 
                continue;
            
            trait.Apply(gameObject,gene);
        }
        if (UIGenesController==null)
            return;
        UIGenesController.SetGenesInUI();
    }

    /// <summary>
    /// Recarrega todas as características definidas.
    /// </summary>
    public void ReloadTraits()
    {
        if (hasParents)
        {
            genes = Gene.CrossGenesList(parent1.genes,parent2.genes);
        }

        ApplyTraits();
    }
    
}
