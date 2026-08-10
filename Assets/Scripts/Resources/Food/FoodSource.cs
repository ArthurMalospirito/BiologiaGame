
using System.Collections;
using Enums.EnumFoodID;
using UnityEngine;

public class FoodSource : MonoBehaviour
{
    [SerializeField] private Food food;
    [SerializeField] private int foodLimit = 5;
    private int foodCount =0;
    [SerializeField] private int spawnAmount=1;
    [SerializeField] private float pushForce=500;
    [Range(0f,1f)][SerializeField] private float pushForceOffset=0.15f;
    [SerializeField] private float spawnCooldown=15;
    [SerializeField] private FoodID foodID;
    public bool Active {get;set;} 
    private Coroutine spawnFoodCoroutine;

    private void OnEnable()
    {
        SetActive(true);
    }

    private void OnDisable()
    {
        SetActive(false);
    }
    private void OnEat()
    {
        foodCount--;
        PlayerStatsManager.Instance.AddFood(foodID);
    }

    private void SpawnFood()
    {
        for (int i=0;i<spawnAmount;i++)
        {
            if (foodCount>=foodLimit) return;
            foodCount++;
            Vector2 direction = Random.insideUnitCircle.normalized;
            Food newFood = Instantiate(food,transform.position,Quaternion.identity, gameObject.transform);
            newFood.MakeIntangible(1f);
            newFood.transform.localScale= DivideVectors(food.transform.localScale,gameObject.transform.lossyScale);
            newFood.AddForce(direction*(pushForce*Random.Range(1-pushForceOffset,1+pushForceOffset)));
        }
    }

    private Vector3 DivideVectors(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    private void SetActive(bool active)
    {
        Active =active;
        if (active)
            spawnFoodCoroutine = StartCoroutine(SpawnFoodCoroutine());
        else
        {
            if(spawnFoodCoroutine==null) return;
            StopCoroutine(spawnFoodCoroutine);
        }
    }
    private IEnumerator SpawnFoodCoroutine()
    {
        while (Active)
        {
            yield return new WaitForSeconds(spawnCooldown);
            SpawnFood();
        }
    }
}
