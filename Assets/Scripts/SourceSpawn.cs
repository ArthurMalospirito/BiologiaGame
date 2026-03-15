using System.Collections;
using UnityEngine;

public class SourceSpawn : MonoBehaviour
{
    public float pushForce=100;
    public float cooldown = 5;
    public int amount =1;
    public SourceItem food;

    [SerializeField] private Transform spawnContainer;

    private Coroutine spawnCoroutine;

    private void OnEnable()
    {
        spawnCoroutine = StartCoroutine(SpawnFoodCoroutine());
    }

    private void OnDisable()
    {
        if (spawnCoroutine!=null)
            StopCoroutine(spawnCoroutine);

    }

    private void SpawnFood()
    {
        for (int i=0;i<amount;i++)
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            SourceItem newFood = Instantiate(food,transform.position,Quaternion.identity, spawnContainer);
            newFood.transform.localScale= new Vector3(0.25f,0.25f,1);
            newFood.AddForce(direction*(pushForce*Random.Range(0.85f,1.15f)));
        }
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