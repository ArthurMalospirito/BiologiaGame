
using Enums.EnumFoodID;
using Unity.VisualScripting;
using UnityEngine;

public class UsesController : MonoBehaviour
{

    [SerializeField] private FoodID trackedFoodID;
    [SerializeField] private int internalAmount=0;
    [SerializeField] private int needAmount = 10;    
    [SerializeField] private UiSlider uiSlider;

    private void OnEnable()
    {
        CalcUses();
    }
    private void CalcUses()
    {
        int foodAmount = PlayerStatsManager.Instance.GetCount(trackedFoodID)-internalAmount;

        while (foodAmount>=needAmount)
        {
            AddUses(1);
            foodAmount-=needAmount;
            internalAmount+=needAmount;
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