
using System;
using System.Collections.Generic;
using Enums.EnumBiomes;
using Enums.EnumFoodID;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance { get; private set; }
    [SerializeField] private CreatureData creatureData;
    public event Action<FoodID, int> OnFoodCountChanged;
    private Dictionary<FoodID, int> foodCounts = new Dictionary<FoodID, int>();
    private DiseaseController diseaseController;

    public static float healthMultipliyer=1;
    public static float foodMultipliyer=1;
    public static float waterMultipliyer=1;
    public static float speedMultipliyer=1;
    public static Biomes biome;
    public static Biomes biomeColorBuff;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        diseaseController=GetComponent<DiseaseController>();
    }

    public void AddFood(FoodID type)
    {
        if (!foodCounts.ContainsKey(type))
            foodCounts[type] = 0;

        foodCounts[type]++;
        OnFoodCountChanged?.Invoke(type, foodCounts[type]);

        diseaseController.OnEat();
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

    public void UpdateDetectionRadius()
    {
        //Se o buff for nenhum por bioma é 1.
        if (biomeColorBuff==Biomes.None)
        {
            creatureData.SetDetectionMultipliyer(1f);
            return;
        }
        //Se o buff for igual o bioma que tá é 0.8.
        if (biomeColorBuff==biome)
        {
            creatureData.SetDetectionMultipliyer(0.8f);
            return;
        }
        //Se o bioma for nulo é 1
        if (biome==Biomes.None)
        {
            creatureData.SetDetectionMultipliyer(1f);
            return;
        }
        //Se não encaixar nada, é 1.2
        creatureData.SetDetectionMultipliyer(1.2f);
        
    }
}