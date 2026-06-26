using Enums.Genotypes;
using UnityEngine;

[CreateAssetMenu(menuName ="Traits/Trait/ColorTrait")]
public class ColorTrait : Trait
{
    [SerializeField]private CreatureData creatureData;
    [SerializeField]private Color colorHomoDominant = Color.brown;
    [SerializeField]private float homoDominantDetectionMultipliyer=0.8f;
    [SerializeField]private Color colorHetero = Color.beige;
    [SerializeField]private float heteroDetectionMultipliyer=1f;
    [SerializeField]private Color colorHomoRecessive = Color.white;
    [SerializeField]private float homoRecessiveDetectionMultipliyer=1.2f;

    public override void Apply(GameObject target,Gene gene)
    {
        SpriteRenderer[] spriteRenderers = target.GetComponentsInChildren<SpriteRenderer>();

        if (spriteRenderers==null)
        {
            Debug.LogError("Não achei SpriteRenderer para colocar a cor");
            return;
        }

        Color color = gene.Genotype switch
        {
            Genotypes.HomoDominant => colorHomoDominant,
            Genotypes.Hetero => colorHetero,
            Genotypes.HomoRecessive => colorHomoRecessive,
            _ => Color.red
        };

        foreach(var spriteRenderer in spriteRenderers)
        {
            if (spriteRenderer.gameObject.CompareTag("NoPaint")) continue;
            spriteRenderer.color=color;
        }

        if (!target.CompareTag("Player")) return;
        if (creatureData==null)
        {
            Debug.Log("Sem creatureData");
            return;
        }
        float newDetectionMultipliyer= gene.Genotype switch
        {
            Genotypes.HomoDominant => homoDominantDetectionMultipliyer,
            Genotypes.Hetero => heteroDetectionMultipliyer,
            Genotypes.HomoRecessive => homoRecessiveDetectionMultipliyer,
            _ => heteroDetectionMultipliyer
        };

        creatureData.SetDetectionMultipliyer(newDetectionMultipliyer);
            
    }
}
