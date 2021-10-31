using System;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Is thrown when an upgrade encountered an incompatible spell during casting.
    /// </summary>
    public class IncompatibleUpgradeException : Exception
    {
        /// <summary>
        /// The formatted message returned when an incompatible upgrade exception happens.
        /// </summary>
        private const string FORMATTED_MESSAGE = "Expected the spell to be a {0} but it was a {1}.";

        /// <summary>
        /// Creates a new instance without message.
        /// </summary>
        public IncompatibleUpgradeException() : base() { }

        /// <summary>
        /// Creates a new instance with expected and actual spell type names.
        /// </summary>
        /// <param name="expectedSpellType">The expected spell type name.</param>
        /// <param name="actualSpellType">The actual spell type name.</param>
        public IncompatibleUpgradeException(string expectedSpellType, string actualSpellType)
            : base(string.Format(FORMATTED_MESSAGE, expectedSpellType, actualSpellType))
        {
        }

        /// <summary>
        /// Creates a new instance with message.
        /// </summary>
        /// <param name="message">The message.</param>
        public IncompatibleUpgradeException(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance with message and inner exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public IncompatibleUpgradeException(string message, Exception inner) : base(message, inner) { }
    }
}
