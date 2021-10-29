using System;

namespace BWolf.Patterns.Factory
{
    /// <summary>
    /// Represents health status points used for a <see cref="SquireBehaviour"/>.
    /// </summary>
    [Serializable]
    public class SquireHealthPoints : StatusPoints
    {
        /// <summary>
        /// Initializes the health points with default values.
        /// </summary>
        public SquireHealthPoints() : base(DEFAULT_MAX_POINT) { }

        /// <summary>
        /// Initializes the health points with a maximum amount of health points.
        /// </summary>
        /// <param name="maxHealth">The maximum amount of health points.</param>
        public SquireHealthPoints(int maxHealth) : base(maxHealth) { }
    }
}
