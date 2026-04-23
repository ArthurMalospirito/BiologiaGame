using System.Collections;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private HealthController healthController;
    [SerializeField] private int damageWithZeroResource=2;

    private int xp;
    [SerializeField] private int needXP=50;
    [SerializeField] private UiSlider XpBar;

    private float food;
    [SerializeField] private float maxFood=100;
    [SerializeField] private float foodLooseAmount=0.1f;
    [SerializeField] private  UiSlider FoodBar;

    private float water;
    [SerializeField] private float maxWater=100;
    [SerializeField] private float waterLooseAmount=0.1f;
    [SerializeField] private UiSlider WaterBar;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(LooseResourcesCoroutine));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(LooseResourcesCoroutine));
    }
    private void Start()
    {
        water = maxWater;
        food= maxFood;
    }
    public void addXp(int amount)
    {
        xp+=amount;

        if (xp>=needXP)
        {
            UpgradeXp();
        }
        SendMessage("OnXpChange",xp,SendMessageOptions.DontRequireReceiver);
        XpBar.SetFill(xp,needXP);


    }

    public void UpgradeXp()
    {
        xp-=needXP;
        needXP+=50;

    }

    public void addFood(float amount)
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
    public void addWater(float amount)
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
            addWater(-waterLooseAmount);
            addFood(-foodLooseAmount);
        
        }
    }



}
