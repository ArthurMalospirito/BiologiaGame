using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitList", menuName = "Traits/TraitList")]
public class TraitList : ScriptableObject
{
    public List<Trait> TraitsList;
}
