
using System.Collections;
using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField] private float timeToBorn=15;   
    private GeneticController geneticController;

    private void Awake()
    {
        geneticController = GetComponentInChildren<GeneticController>(true);
    }
    private void Start()
    {
        StartCoroutine(BornCoroutine(timeToBorn));
    }
    private IEnumerator BornCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (geneticController!=null)
        {
            geneticController.gameObject.SetActive(true);
            geneticController.ApplyTraits();
            geneticController.transform.SetParent(null,worldPositionStays:true);
        }
        //Animação Aqui
        Destroy(gameObject);

    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}