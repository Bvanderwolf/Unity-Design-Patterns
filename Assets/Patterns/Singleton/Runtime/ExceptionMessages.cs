using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BWolf.Patterns.Singleton.Exceptions
{
    public enum ExceptionMessage
    {
        INVALID_PROFILE = 0,
        
        IS_BEING_DESTROYED_BY_APP = 1,
        
        DISABLED_SINGLETON = 2,
        
        INVALID_SCENE_SINGLETON = 3,
        
        MISSING_PREFAB = 4,
        
        MISSING_BOOT_INFO = 5,
    }
    
    public static class ExceptionMessages
    {
        private static readonly Dictionary<ExceptionMessage, string> _messages = new Dictionary<ExceptionMessage, string>
        {
            { ExceptionMessage.INVALID_PROFILE, "An invalid profile has been detected during the instantiation of the {0} singleton. Make sure there is a profile in the project and the singleton is part of it." },
            { ExceptionMessage.IS_BEING_DESTROYED_BY_APP, "{0} its instance was accessed while it was being destroyed by the application quit event. This is probably  because of an OnDestroy call to it during application quit. There is no guarantee that it will  be alive during this time. Use the 'Exists' property or the 'OnBeforeDestroy' event instead."},
            { ExceptionMessage.DISABLED_SINGLETON, "The {0} singleton its instantiation call was made while it has been set to disabled. Make sure to set the mode correctly." },
            { ExceptionMessage.INVALID_SCENE_SINGLETON, "The {0} singleton could not be instantiated because its scene was not loaded. Make sure the scene is loaded and the instance call is made after (or by delaying) the Start function." },
            { ExceptionMessage.MISSING_PREFAB, "Encountered invalid singleton :: The prefab at index {0} of profile '{1}' is missing." },
            { ExceptionMessage.MISSING_BOOT_INFO, "The {0} singleton has been accessed but its boot info could not be found. Make sure it is part of the profile and has the component on the prefab." },
        };

        public static string GetFor<T>(ExceptionMessage message)
        {
            return string.Format(_messages[message], typeof(T).Name);
        }

        public static string Get(ExceptionMessage message, params object[] args)
        {
            return string.Format(_messages[message], args);
        }
    }
}
