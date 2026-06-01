
using System.Collections;
using UnityEngine;

public class EggController : MonoBehaviour
{
    
    private GeneticController geneticController;

    private void Awake()
    {
        geneticController = GetComponentInChildren<GeneticController>(true);
    }
    private void Start()
    {
        StartCoroutine(BornCoroutine(5));
    }
    private IEnumerator BornCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        geneticController.gameObject.SetActive(true);
        geneticController.ApplyTraits();
        geneticController.transform.SetParent(null,worldPositionStays:true);
        //Animação Aqui
        Destroy(gameObject);

    }
}