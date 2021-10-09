using UnityEngine;

/// <summary>
/// The actor behaviour for which a health status object can be created.
/// </summary>
public class ActorBehaviour : MonoBehaviour
{
    /// <summary>
    /// The health status points for this actor.
    /// </summary>
    [SerializeField]
    private StatusPoints _health;

    /// <summary>
    /// The health status points for this actor.
    /// </summary>
    public StatusPoints Health => _health;

    /// <summary>
    /// Assigns the health status when added to a game object or when the reset feature
    /// is used in the inspector on this component.
    /// </summary>
    protected virtual void Reset() => _health = StatusPointsFactory.CreateHealthForActor(GetType());
}
