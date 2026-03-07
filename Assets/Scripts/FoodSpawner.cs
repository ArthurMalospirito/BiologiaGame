using System.Collections;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float pushForce=100;
    public float cooldown = 5;
    public Food food;

    private void OnEnable()
    {
        StartCoroutine(nameof(SpawnFoodCoroutine));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(SpawnFoodCoroutine));
    }
    private void SpawnFood()
    {
        Vector2 direction = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;
        Food newFood = Instantiate(food,transform.position,Quaternion.identity);
        newFood.AddForce(direction*(pushForce*Random.Range(0.85f,1.15f)));
    }

    private IEnumerator SpawnFoodCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            SpawnFood();
        }
    }
}
