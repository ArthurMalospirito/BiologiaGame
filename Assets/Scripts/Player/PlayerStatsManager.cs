
using System;
using System.Collections.Generic;
using Enums.EnumFoodID;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance { get; private set; }
    public event Action<FoodID, int> OnFoodCountChanged;
    private Dictionary<FoodID, int> foodCounts = new Dictionary<FoodID, int>();
    public static float healthMultipliyer=1;
    public static float foodMultipliyer=1;
    public static float waterMultipliyer=1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddFood(FoodID type)
    {
        if (!foodCounts.ContainsKey(type))
            foodCounts[type] = 0;

        foodCounts[type]++;
        OnFoodCountChanged?.Invoke(type, foodCounts[type]);
    }
    public void SetFood(FoodID type,int amount)
    {
        if (!foodCounts.ContainsKey(type))
            foodCounts[type] = 0;

        foodCounts[type] = amount;
        OnFoodCountChanged?.Invoke(type, foodCounts[type]);
    }

    public int GetCount(FoodID type)
    {
        return foodCounts.ContainsKey(type) ? foodCounts[type] : 0;
    }
}