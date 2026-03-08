using System.Collections;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public int xp;
    public int needXP=50;
    [SerializeField] private UiSlider XpBar;

    public float food;
    public float maxFood=100;
    public float foodLooseAmount=0.1f;
    [SerializeField] private  UiSlider FoodBar;

    public float water;
    public float maxWater=100;
    public float waterLooseAmount=0.1f;
    [SerializeField] private UiSlider WaterBar;


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
        SendMessage("OnXpChange",xp,SendMessageOptions.RequireReceiver);
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

        SendMessage("OnFoodChange",food,SendMessageOptions.RequireReceiver);
        FoodBar.SetFill(food,maxFood);
    }
    public void addWater(float amount)
    {
        water+=amount;
        if (water>maxWater)
        {
            water=maxWater;
        }

        SendMessage("OnWaterChange",water,SendMessageOptions.RequireReceiver);
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
