using Enums.Traits;
using UnityEngine;

/// <summary>
/// Classe abstrata padrão que define uma característica, sendo elas que tenham um tipo e um método que insira as características de um gene dentro do GameObject escolhido.
/// </summary>
public abstract class Trait : ScriptableObject
{
    /// <summary>
    /// Tipo da característica que será inserida.
    /// </summary>
    [SerializeField] public Traits traitType;
    /// <summary>
    /// Método abristrado que aplica um Gene a um GameObject.
    /// </summary>
    /// <param name="target">GameObject o qual o gene será inserido.</param>
    /// <param name="gene">Gene que define a característica que será colocada dentro do GameObject</param>
    public abstract void Apply(GameObject target,Gene gene);
}
