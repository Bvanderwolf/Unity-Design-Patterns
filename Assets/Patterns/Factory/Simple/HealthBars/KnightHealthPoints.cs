using System;
using UnityEngine;

/// <summary>
/// Represents health status points used for a <see cref="KnightBehaviour"/>.
/// </summary>
[Serializable]
public class KnightHealthPoints : StatusPoints
{
    /// <summary>
    /// The maximum amount of shield used if none is set.
    /// </summary>
    public const int DEFAULT_MAX_SHIELD = 20;

    /// <summary>
    /// The amount of strength set if none is set.
    /// </summary>
    public const float DEFAULT_SHIELD_STRENGTH = 0.5f;

    /// <summary>
    /// The shield status points used toghether with the health points.
    /// </summary>
    [SerializeField]
    private ShieldStatusPoints _shield;

    /// <summary>
    /// The shield status points used toghether with the health points.
    /// </summary>
    public ShieldStatusPoints Shield => _shield;

    /// <summary>
    /// Initializes the health points with default values.
    /// </summary>
    public KnightHealthPoints() : this(new ShieldStatusPoints(DEFAULT_SHIELD_STRENGTH, DEFAULT_MAX_SHIELD))
    {
    }

    /// <summary>
    /// Initialiizes the health points with max health and default shield status points.
    /// </summary>
    /// <param name="maxHealth">The maximum amount of health points to use.</param>
    public KnightHealthPoints(int maxHealth) : this(maxHealth, new ShieldStatusPoints(DEFAULT_SHIELD_STRENGTH, DEFAULT_MAX_SHIELD))
    {
    }

    /// <summary>
    /// Initializes the health points with shield status points and the default amount of health points.
    /// </summary>
    /// <param name="shield">The shield status points.</param>
    public KnightHealthPoints(ShieldStatusPoints shield) : this(DEFAULT_MAX_POINT, shield)
    {
    }

    /// <summary>
    /// Initializes the health points with shield status points and a maximum amount of health points.
    /// </summary>
    /// <param name="shield">The shield status points.</param>
    public KnightHealthPoints(int maxHealth, ShieldStatusPoints shield) : base(maxHealth) => this._shield = shield;

    /// <inheritdoc/>
    public override void Remove(int amount)
    {
        // Remove shield before removing health points.
        _shield.Remove(amount);

        // The damage is now equal to value subtracted from the current shield.
        int damageAfterShield = _shield.Current - amount;

        // If the damage dealt was below zero, the shield couldn't block all damage 
        // and health points are subtracted.
        if (damageAfterShield < 0)
        {
            int damage = Mathf.Abs(damageAfterShield);
            Update(Current - damage);
        }
    }
}
