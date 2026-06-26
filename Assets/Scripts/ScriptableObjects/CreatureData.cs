
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureData", menuName = "Data/CreatureData")]
public class CreatureData : ScriptableObject
{
    [SerializeField]private float baseDetectionRadius = 5f;
    [SerializeField]private float baseDetectionRadiusMultipliyer = 1f;
    public float DetectionRadius {get;private set;}

    private void OnEnable()
    {
        DetectionRadius=baseDetectionRadius*baseDetectionRadiusMultipliyer;
    }
    public void SetDetectionMultipliyer(float value)
    {
        DetectionRadius= baseDetectionRadius*value;

    }
}