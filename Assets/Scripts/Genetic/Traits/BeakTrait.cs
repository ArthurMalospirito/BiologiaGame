
using Enums.EnumFoodType;
using Enums.Genotypes;
using UnityEngine;

[CreateAssetMenu(menuName ="Traits/Trait/BeakTrait")]
public class BeakTrait : Trait
{
    [SerializeField]private Sprite spriteHomoDominant;
    [SerializeField]private Sprite spriteHetero;
    [SerializeField]private Sprite spriteHomoRecessive;

    public override void Apply(GameObject target,Gene gene)
    {
        GameObject beakGameObject = target.transform.Find("Head/Beak").gameObject;

        if (beakGameObject==null)
        {
            Debug.LogError("Não achei o elemento de Bico dentro do player!");
            return;
        }

        SpriteRenderer BeakSpriteRenderer = beakGameObject.GetComponent<SpriteRenderer>();
        if (BeakSpriteRenderer==null)
        {
            Debug.LogError("Não achei BeakSpriteRenderer para mudar o Rabo");
            return;   
        }
        
        Sprite sprite = gene.genotype switch
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

        BeakSpriteRenderer.sprite = sprite;

        ResourceController resourceController = target.GetComponent<ResourceController>();
        if (resourceController==null)
        {
            return;
        }

        resourceController.CanEatType = gene.genotype switch
        {
            Genotypes.HomoDominant => FoodTypes.ThickBeak,
            Genotypes.Hetero => FoodTypes.ThickBeak,
            Genotypes.HomoRecessive => FoodTypes.ThinBeak,
            _ => FoodTypes.ThickBeak
        };

    }
}
