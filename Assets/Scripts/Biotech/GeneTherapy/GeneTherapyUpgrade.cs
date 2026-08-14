
using UnityEngine;

public class GeneTherapyUpgrade : MonoBehaviour
{
    private Player player;
    [SerializeField] private UiSlider healthBar;
    [SerializeField] private UiSlider foodBar;
    [SerializeField] private UiSlider waterBar;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void CloseSelf()
    {
        gameObject.SetActive(false);
    }
    public void OnHealthUpgrade()
    {
        PlayerStatsManager.healthMultipliyer+=0.1f;
        var playerHealthController = player.GetComponent<HealthController>();
        if (playerHealthController==null)
        {
            Debug.LogError("Não tem HealthController no Player");
            return;
        }
        playerHealthController.UpdateStats();
        playerHealthController.AddHealth(1000);
        healthBar.GrowBar(0.1f);
        CloseSelf();
    }

    public void OnFoodUpgrade()
    {
        PlayerStatsManager.foodMultipliyer+=0.1f;
        var playerResourceController = player.GetComponent<ResourceController>();
        if (playerResourceController==null)
        {
            Debug.LogError("Não tem ResourceController no Player");
            return;
        }
        playerResourceController.UpdateStats();
        foodBar.GrowBar(0.1f);
        playerResourceController.AddFood(1000);
        CloseSelf();
    }
    
    public void OnWaterUpgrade()
    {
        PlayerStatsManager.waterMultipliyer+=0.1f;
        var playerResourceController = player.GetComponent<ResourceController>();
        if (playerResourceController==null)
        {
            Debug.LogError("Não tem ResourceController no Player");
            return;
        }
        playerResourceController.UpdateStats();
        waterBar.GrowBar(0.1f);
        playerResourceController.AddWater(1000);
        CloseSelf();
    }

    public void OnSpeedUpgrade()
    {
        //A fazer
    }
}