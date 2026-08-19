using Enums.EnumBiomes;
using Enums.Genotypes;
using UnityEngine;

[CreateAssetMenu(menuName ="Traits/Trait/ColorTrait")]
public class ColorTrait : Trait
{
    [SerializeField]private Color colorHomoDominant = Color.brown;
    [SerializeField]private Biomes homoDominantBiomeColorBuff=Biomes.Desert;
    [SerializeField]private Color colorHetero = Color.beige;
    [SerializeField]private Biomes heteroBiomeColorBuff=Biomes.Florest;
    [SerializeField]private Color colorHomoRecessive = Color.white;
    [SerializeField]private Biomes homoRecessiveBiomeColorBuff=Biomes.None;

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

        PlayerStatsManager.biomeColorBuff = gene.Genotype switch
        {
            Genotypes.HomoDominant => homoDominantBiomeColorBuff,
            Genotypes.Hetero => heteroBiomeColorBuff,
            Genotypes.HomoRecessive => homoRecessiveBiomeColorBuff,
            _ => heteroBiomeColorBuff
        };
            
    }
}
