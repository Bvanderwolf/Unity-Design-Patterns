using System;
using UnityEngine;

/// <summary>
/// Represents shield status points that might be used by
/// for example <see cref="KnightHealthPoints"/>.
/// </summary>
[Serializable]
public class ShieldStatusPoints : StatusPoints
{
    /// <summary>
    /// The strength of the shield.
    /// </summary>
    [SerializeField]
    private float _strength;

    /// <summary>
    /// The strength of the shield.
    /// </summary>
    public float Strength => _strength;

    /// <summary>
    /// The default strength to use if none is set.
    /// </summary>
    public const float DEFAULT_STRENGTH = 0.25f;

    /// <summary>
    /// Initializes the status points with default values.
    /// </summary>
    public ShieldStatusPoints() : this(DEFAULT_STRENGTH) { }

    /// <summary>
    /// Initializes the status points with a strength amount.
    /// </summary>
    /// <param name="strength">The strength amount.</param>
    public ShieldStatusPoints(float strength) : this(strength, DEFAULT_MAX_POINT) { }

    /// <summary>
    /// Initializes the status points with a strength amount and maximum amount of shield.
    /// </summary>
    /// <param name="strength">The strength amount.</param>
    /// <param name="maxShield">The maximum amount of shield to use.</param>
    public ShieldStatusPoints(float strength, int maxShield) : base(maxShield) => _strength = Mathf.Clamp01(strength);

    /// <inheritdoc/>
    public override void Remove(int amount)
    {
        // Determine amount after shield strength is applied.
        float amountAfterShield = amount * (1.0f - _strength);

        // Update the current value with the amount after shield rounded to the nearest integer value.
        Update(Current - Mathf.RoundToInt(amountAfterShield));
    }
}
