using System;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Represents a spell with a cast time.
    /// </summary>
    public abstract class Spell
    {
        /// <summary>
        /// The cast time of the spell.
        /// </summary>
        public float castTime;

        /// <summary>
        /// Initializes the spell with a cast time.
        /// </summary>
        /// <param name="castTime">The cast time of the spell.</param>
        public Spell(float? castTime)
        {
            if (!castTime.HasValue)
                return;

            if (castTime.Value < 0)
                throw new ArgumentException("Cast time for a spell can't be smaller than zero.");

            this.castTime = castTime.Value;
        }

        /// <summary>
        /// Starts casting the spell from casting actor to target actor.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public abstract void OnCast(ActorBehaviour caster, ActorBehaviour target);

        /// <summary>
        /// Called when the spell has hit the target, additional effects can be applied.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public abstract void OnHit(ActorBehaviour caster, ActorBehaviour target);

        /// <summary>
        /// Resets the spells internal state.
        /// </summary>
        public virtual void Reset() => this.castTime = 0;

        /// <summary>
        /// Sets the base configuration values for the spell.
        /// </summary>
        public virtual void SetBaseValues() { }
    }
}
