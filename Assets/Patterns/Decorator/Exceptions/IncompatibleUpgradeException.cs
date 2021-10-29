using System;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Is thrown when an upgrade encountered an incompatible spell during casting.
    /// </summary>
    public class IncompatibleUpgradeException : Exception
    {
        private const string FORMATTED_MESSAGE = "Expected the spell to be a {0} but it was a {1}.";

        public IncompatibleUpgradeException() : base() { }

        public IncompatibleUpgradeException(string expectedSpellType, string actualSpellType)
            : base(string.Format(FORMATTED_MESSAGE, expectedSpellType, actualSpellType))
        {
        }

        public IncompatibleUpgradeException(string message) : base(message) { }

        public IncompatibleUpgradeException(string message, Exception inner) : base(message, inner) { }
    }
}
