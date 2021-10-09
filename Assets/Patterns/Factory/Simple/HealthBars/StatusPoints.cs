using System;
using UnityEngine;

/// <summary>
/// An abstract representation of status points to be implemented
/// for example as health points of an actor.
/// </summary>
[Serializable]
public class StatusPoints
{
    /// <summary>
    /// The maximum amount of status points this object can have.
    /// </summary>
    [SerializeField]
    private int _max;

    /// <summary>
    /// The current amount of status points this object has.
    /// </summary>
    [SerializeField]
    private int _current;

    /// <summary>
    /// The maximum amount of status points this object can have.
    /// </summary>
    public int Max => _max;

    /// <summary>
    /// The current amount of status points this object has.
    /// </summary>
    public int Current => _current;

    /// <summary>
    /// The default maximum amount of status points used if none is set.
    /// </summary>
    public const int DEFAULT_MAX_POINT = 100;

    /// <summary>
    /// Sets the maximum and current amount of status points for this object.
    /// </summary>
    /// <param name="maxPoints">The maximum amount of status points this object can have.</param>
    public StatusPoints(int maxPoints)
    {
        _max = maxPoints;
        _current = Max;
    }

    /// <summary>
    /// Sets the new current status point amount for this object.
    /// This value will be clamped between 0 and <see cref="Max"/>.
    /// </summary>
    /// <param name="newCurrent">The new current amount of status points.</param>
    public void Update(int newCurrent) => Mathf.Clamp(newCurrent, 0, Max);

    /// <summary>
    /// Removes status points from this object.
    /// </summary>
    /// <param name="amount">The amount to remove.</param>
    public virtual void Remove(int amount) => Update(_current - amount);

    /// <summary>
    /// Adds status points to this object.
    /// </summary>
    /// <param name="amount">The amount to add.</param>
    public virtual void Add(int amount) => Update(_current + amount);
}
