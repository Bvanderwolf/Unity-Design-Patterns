using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.Patterns.Singleton
{
    public enum ExceptionMessage
    {
        INVALID_PROFILE
    }
    
    public static class ExceptionMessages
    {
        private static readonly Dictionary<ExceptionMessage, string> _messages = new Dictionary<ExceptionMessage, string>
        {
            { ExceptionMessage.INVALID_PROFILE, "An invalid profile has been detected during the instantiation of the {0} singleton. Make sure there is a profile in the project and the singleton is part of it." }
        };

        public static string GetFor<T>(ExceptionMessage message)
        {
            return string.Format(_messages[message], typeof(T).Name);
        }
    }
}
