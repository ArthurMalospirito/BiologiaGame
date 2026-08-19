
using Enums.EnumBiomes;
using UnityEngine;

public class BiomeTrigger :MonoBehaviour
{
    [SerializeField] private Biomes biome;
    [SerializeField] private string targetTag="Player";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag)) return;
        PlayerStatsManager.biome = biome;
        PlayerStatsManager.Instance.UpdateDetectionRadius();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag)) return;
        PlayerStatsManager.biome = Biomes.None;
        PlayerStatsManager.Instance.UpdateDetectionRadius();
    }
}