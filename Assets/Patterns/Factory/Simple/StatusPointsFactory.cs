using System;
using System.Collections.Generic;

/// <summary>
/// This static factory class can create a health status object for an actor.
/// </summary>
public static class StatusPointsFactory
{
    /// <summary>
    /// The delegate used for creating a new status points object for an actor.
    /// </summary>
    /// <param name="maxPoints">The maximum health given to the health points object.</param>
    /// <returns>The status points object.</returns>
    private delegate StatusPoints StatusConstructor(int maxPoints);

    /// <summary>
    /// Contains a status points constructor method for each behaviour that inherits from the actor behaviour class.
    /// </summary>
    private static readonly Dictionary<Type, StatusConstructor> _factoryMap = new Dictionary<Type, StatusConstructor>
    {
        { typeof(SquireBehaviour), (maxPoints) => new SquireHealthPoints(maxPoints) },
        { typeof(PriestBehaviour), (maxPoints) => new PriestHealthPoints(maxPoints) },
        { typeof(KnightBehaviour), (maxPoints) => new KnightHealthPoints(maxPoints) },
    };

    /// <summary>
    /// Creates a new health status points object for an actor.
    /// </summary>
    /// <param name="actorType">The actor type to create the health status points for.</param>
    /// <returns>The health status points.</returns>
    public static StatusPoints CreateHealthForActor(Type actorType) => CreateHealthForActor(actorType, StatusPoints.DEFAULT_MAX_POINT);

    /// <summary>
    /// Creates a new health status points object for an actor of type T.
    /// </summary>
    /// <typeparam name="T">The type of status points to return.</typeparam>
    /// <param name="actorType">The actor type to create the health status points for.</param>
    /// <returns>The health status points.</returns>
    public static T CreateHealthForActor<T>(Type actorType) where T : StatusPoints => (T)CreateHealthForActor(actorType);

    /// <summary>
    /// Creates a new health status points object for an actor.
    /// </summary>
    /// <param name="actorType">The actor type to create the health status points for.</param>
    /// <param name="maxHealth">The maximum health point amount to set.</param>
    /// <returns>The health status points.</returns>
    public static StatusPoints CreateHealthForActor(Type actorType, int maxHealth)
    {
        if (!_factoryMap.ContainsKey(actorType))
            throw new ArgumentException("Actor type was not usable for status points factory.");

        return _factoryMap[actorType](maxHealth);
    }

}
