namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Represents a spell that deals damage over time to an actor.
    /// </summary>
    public class Poison : DamageSpell
    {
        /// <summary>
        /// The time it takes for the poison to do damage.
        /// </summary>
        public float time;

        /// <summary>
        /// The frequency with which the poison damage is done.
        /// </summary>
        public float frequency;

        /// <summary>
        /// Initializes the poison spell with values for its internal state.
        /// </summary>
        /// <param name="damage">The damage the rupture will do.</param>
        /// <param name="time">The time it takes for the poison to do damage.</param>
        /// <param name="frequency">The frequency with which the poison damage is done.</param>
        /// <param name="castTime">The cast time of the spell.</param>
        public Poison(int damage, float time, float frequency, float castTime) : base(damage, castTime)
        {
            this.time = time;
            this.frequency = frequency;
        }

        /// <summary>
        /// Initializes the poison spell with base configuration values.
        /// </summary>
        public Poison() : this(
            SpellConfig.BASE_POISON_DAMAGE,
            SpellConfig.BASE_POISON_TIME,
            SpellConfig.BASE_POISON_FREQUENCY,
            SpellConfig.BASE_POISON_CAST_TIME)
        {

        }

        ///<inheritdoc/>
        public override void OnCast(ActorBehaviour caster, ActorBehaviour target) => target.AddDamageStatus(time, frequency, damage);

        ///<inheritdoc/>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
        }
    }
}