using Enums.Genotypes;
using UnityEngine;

[CreateAssetMenu(menuName ="Traits/Trait/ColorTrait")]
public class ColorTrait : Trait
{
    [SerializeField]private Color colorHomoDominant = Color.brown;
    [SerializeField]private Color colorHetero = Color.beige;
    [SerializeField]private Color colorHomoRecessive = Color.white;

    public override void Apply(GameObject target,Gene gene)
    {
        SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();

        if (spriteRenderer== null)
        {
            Debug.LogError("Não achei SpriteRenderer para colocar a cor");
            return;
        }

        Color color = gene.genotype switch
        {
            Genotypes.HomoDominant => colorHomoDominant,
            Genotypes.Hetero => colorHetero,
            Genotypes.HomoRecessive => colorHomoRecessive,
            _ => Color.red
        };

        spriteRenderer.color = color;
            
    }
}
