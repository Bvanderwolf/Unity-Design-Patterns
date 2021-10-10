using UnityEngine;

namespace BWolf.Patterns.Factory.Simple
{
    /// <summary>
    /// The actor behaviour for which a health status object can be created.
    /// </summary>
    public class ActorBehaviour<T> : MonoBehaviour where T : StatusPoints
    {
        /// <summary>
        /// The health status points for this actor.
        /// </summary>
        [SerializeField]
        private T _health;

        /// <summary>
        /// The health status points for this actor.
        /// </summary>
        public T Health => _health;

        /// <summary>
        /// Assigns the health status when added to a game object or when the reset feature
        /// is used in the inspector on this component.
        /// </summary>
        protected virtual void Reset() => _health = StatusPointsFactory.CreateHealthForActor<T>(GetType());
    }

}