
using Enums.EnumFoodID;
using Unity.VisualScripting;
using UnityEngine;

public class UsesController : MonoBehaviour
{

    [SerializeField] private FoodID trackedFoodID;
    [SerializeField] private int needAmount = 10;    
    [SerializeField] private UiSlider uiSlider;

    private void OnEnable()
    {
        CalcUses();
    }
    private void CalcUses()
    {
        int foodAmount = PlayerStatsManager.Instance.GetCount(trackedFoodID);

        while (foodAmount>=needAmount)
        {
            AddUses(1);
            foodAmount-=needAmount;
            PlayerStatsManager.Instance.SetFood(trackedFoodID,foodAmount);
        }
        uiSlider.SetFill(foodAmount,needAmount);
    }
    private void AddUses(int amount)
    {
        for (int i=0;i<amount;i++)
        {
            SendMessage("AddUse",SendMessageOptions.RequireReceiver);
        }
    }
}