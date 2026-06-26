using Enums.Genotypes;
using UnityEngine;

[CreateAssetMenu(menuName ="Traits/Trait/TailTrait")]
public class TailTrait : Trait
{
    [SerializeField]private Sprite spriteHomoDominant;
    [SerializeField]private Sprite spriteHetero;
    [SerializeField]private Sprite spriteHomoRecessive;

    public override void Apply(GameObject target,Gene gene)
    {
        GameObject tailGameObject = target.transform.Find("Tail").gameObject;

        if (tailGameObject==null)
        {
            Debug.LogError("Não achei o elemento de Rabo dentro do player!");
            return;
        }
        SpriteRenderer TailSpriteRenderer = tailGameObject.GetComponent<SpriteRenderer>();
        if (TailSpriteRenderer==null)
        {
            Debug.LogError("Não achei TailSpriteRenderer para mudar o Rabo");
            return;   
        }
        
        Sprite sprite = gene.Genotype switch
        {
            Genotypes.HomoDominant => spriteHomoDominant,
            Genotypes.Hetero => spriteHetero,
            Genotypes.HomoRecessive => spriteHomoRecessive,
            _ => null
        };

        if (sprite==null)
        {
            Debug.LogError("Sprite não definido para esse fenótipo!");
            return;
        }

        TailSpriteRenderer.sprite = sprite;

    }
}
