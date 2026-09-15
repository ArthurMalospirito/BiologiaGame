
using UnityEngine;

public class SecretIslandController :MonoBehaviour
{
    [SerializeField] private GameObject secretIsland;
    [SerializeField] private GameObject[] islandLocaitons;

    private void Start()
    {
        var value = Random.Range(0,islandLocaitons.Length);
        var chosenIsland = islandLocaitons[value];

        float angle = value switch
        {
            0 => 0,
            1 => 270,
            2 => 180,
            3 => 90,
            _ => 0
        };

        Instantiate(secretIsland,chosenIsland.transform.position, Quaternion.Euler(0,0,angle),chosenIsland.transform);
    }
}