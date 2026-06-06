using Enums.Genotypes;
using UnityEngine;

[CreateAssetMenu(menuName ="Traits/Trait/WingTrait")]
public class WingTrait : Trait
{
    [SerializeField]private Sprite spriteHomoDominant;
    [SerializeField] private float flightTimeHomoDominant;
    [SerializeField] private float flightSpeedMultipliyerHomoDominant;
    [SerializeField] private float flightCooldownHomoDominant;
    [SerializeField]private Sprite spriteHetero;
    [SerializeField] private float flightTimeHetero;
    [SerializeField] private float flightSpeedMultipliyerHetero;
    [SerializeField] private float flightCooldownHetero;
    [SerializeField]private Sprite spriteHomoRecessive;
    [SerializeField] private float flightTimeHomoRecessive;
    [SerializeField] private float flightSpeedMultipliyerHomoRecessive;
    [SerializeField] private float flightCooldownHomoRecessive;

    public override void Apply(GameObject target,Gene gene)
    {
        GameObject WingGameObject1 = target.transform.Find("Wings/Wing1").gameObject;
        GameObject WingGameObject2 = target.transform.Find("Wings/Wing2").gameObject;

        if (WingGameObject1==null || WingGameObject2==null)
        {
            Debug.LogError("Não achei o elemento de assa dentro do player!");
            return;
        }

        SpriteRenderer WingSpriteRenderer1 = WingGameObject1.GetComponent<SpriteRenderer>();
        SpriteRenderer WingSpriteRenderer2 = WingGameObject2.GetComponent<SpriteRenderer>();
        if (WingSpriteRenderer1==null || WingSpriteRenderer2==null)
        {
            Debug.LogError("Não achei Sprite renderer para mudar o assas");
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

        WingSpriteRenderer1.sprite = sprite;
        WingSpriteRenderer2.sprite = sprite;

        //Aqui só afeta o player
        PlayerFlight playerFlight = target.GetComponent<PlayerFlight>();

        if (playerFlight==null)
        {
            return;
        }

        float flightTime = gene.genotype switch
        {
            Genotypes.HomoDominant => flightTimeHomoDominant,
            Genotypes.Hetero => flightTimeHetero,
            Genotypes.HomoRecessive => flightTimeHomoRecessive,
            _ => 0
        };
        float flightSpeedMultipliyer = gene.genotype switch
        {
            Genotypes.HomoDominant => flightSpeedMultipliyerHomoDominant,
            Genotypes.Hetero => flightSpeedMultipliyerHetero,
            Genotypes.HomoRecessive => flightSpeedMultipliyerHomoRecessive,
            _ => 0
        };

        float flightCooldown = gene.genotype switch
        {
            Genotypes.HomoDominant => flightCooldownHomoDominant,
            Genotypes.Hetero => flightCooldownHetero,
            Genotypes.HomoRecessive => flightCooldownHomoRecessive,
            _ => 0
        };

        if (flightTime==0 || flightSpeedMultipliyer==0 || flightCooldown==0)
        {
            Debug.Log("Alguma das características do voo não foram definidas");
            return;
        }

        playerFlight.flightTime=flightTime;
        playerFlight.flightSpeedMultipliyer=flightSpeedMultipliyer;
        playerFlight.flightCooldown=flightCooldown;

    }
}
