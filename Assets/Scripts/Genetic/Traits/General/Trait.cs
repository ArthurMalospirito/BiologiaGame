using Enums.Traits;
using UnityEngine;

public abstract class Trait : ScriptableObject
{

    [SerializeField] public Traits traitType;

    public abstract void Apply(GameObject target,Gene gene);
}
