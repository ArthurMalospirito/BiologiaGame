using System.Collections;
using Enums.EnumFoodType;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private HealthController healthController;
    [SerializeField] private int damageWithZeroResource=2;

    [Header("Food")]
    private float food;
    [field: SerializeField] public FoodTypes CanEatType {get; set;}
    [SerializeField] private float initialMaxFood=100;
    private float maxFood=100;
    [SerializeField] private float foodLooseAmount=0.1f;
    [SerializeField] private  UiSlider FoodBar;
    [SerializeField][Range(0,1)] private float percentageToRegenHealth = 0.75f;
    [SerializeField]private float healthPerSecond = 1;

    [Header("Water")]
    private float water;
    [SerializeField] private float initialMaxWater=100;
    private float maxWater=100;
    [SerializeField] private float waterLooseAmount=0.1f;
    [SerializeField] private UiSlider WaterBar;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(LooseResourcesCoroutine));
        maxFood=initialMaxFood*PlayerStatsManager.foodMultipliyer;
        maxWater=initialMaxWater*PlayerStatsManager.waterMultipliyer;
        StartCoroutine(nameof(RegenHealthCoroutine));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(LooseResourcesCoroutine));
        StopCoroutine(nameof(RegenHealthCoroutine));
    }
    private void Start()
    {
        water = maxWater;
        food= maxFood;
    }

    public void AddFood(float amount)
    {
        food+=amount;
        if (food>maxFood)
        {
            food=maxFood;
        }
        if (food<=0)
        {
            food = 0;
            healthController.Damage(damageWithZeroResource);
        }

        SendMessage("OnFoodChange",food,SendMessageOptions.DontRequireReceiver);
        FoodBar.SetFill(food,maxFood);
    }
    public void AddWater(float amount)
    {
        water+=amount;
        if (water>maxWater)
        {
            water=maxWater;
        }
        if (water<=0)
        {
            water = 0;
            healthController.Damage(damageWithZeroResource);
        }

        SendMessage("OnWaterChange",water,SendMessageOptions.DontRequireReceiver);
        WaterBar.SetFill(water,maxWater);
    }

    private IEnumerator LooseResourcesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddWater(-waterLooseAmount);
            AddFood(-foodLooseAmount);
        
        }
    }

    public void UpdateStats()
    {
        maxFood=initialMaxFood*PlayerStatsManager.foodMultipliyer;
        maxWater=initialMaxWater*PlayerStatsManager.waterMultipliyer;
    }

    private IEnumerator RegenHealthCoroutine()
    {  
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if ((food/maxFood)>percentageToRegenHealth)
            {
                healthController.AddHealth(healthPerSecond);
            }
        }
    }

}
