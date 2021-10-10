using System;
using UnityEngine;

namespace BWolf.Patterns.Factory.Simple
{
    /// <summary>
    /// Represents health status points used for a <see cref="PriestBehaviour"/>.
    /// </summary>
    [Serializable]
    public class PriestHealthPoints : StatusPoints
    {
        /// <summary>
        /// The amount of health power the priest has.
        /// <para>This is used when adding health points.</para>
        /// </summary>
        [SerializeField]
        private float _healPower;

        /// <summary>
        /// The amount of health power the priest has.
        /// <para>This is used when adding health points.</para>
        /// </summary>
        public float HealPower => _healPower;

        /// <summary>
        /// The default health power used if none is set.
        /// </summary>
        public const float DEFAULT_HEAL_POWER = 0.25f;

        /// <summary>
        /// Initializes the health points with default values.
        /// </summary>
        public PriestHealthPoints() : this(DEFAULT_HEAL_POWER) { }

        /// <summary>
        /// Initializes the health points with heal power 
        /// and the default maximum amount of health points.
        /// </summary>
        /// <param name="healPower">The heal power to use.</param>
        public PriestHealthPoints(float healPower) : this(DEFAULT_MAX_POINT, healPower) { }

        /// <summary>
        /// Initializes the health points with heal power and a maximum amount of health.
        /// </summary>
        /// <param name="maxHealth">The maximum amount of health points to use.</param>
        /// <param name="healPower">The health power to use.</param>
        public PriestHealthPoints(int maxHealth, float healPower) : base(maxHealth) => _healPower = Mathf.Clamp01(healPower);

        /// <inheritdoc/>
        public override void Add(int amount)
        {
            float extra = amount * HealPower;
            Update(Current + amount + Mathf.RoundToInt(extra));
        }
    }
}
