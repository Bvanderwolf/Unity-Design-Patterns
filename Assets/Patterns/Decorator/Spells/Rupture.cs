namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Represents a spell that creates a rupture in the ground damaging
    /// actors standing on top of it.
    /// </summary>
    public class Rupture : DamageSpell
    {
        /// <summary>
        /// The radius of the rupture object.
        /// </summary>
        public float radius;

        /// <summary>
        /// Initializes the rupture spell with values for its internal state.
        /// </summary>
        /// <param name="damage">The damage the rupture will do.</param>
        /// <param name="radius">The radius of the rupture object.</param>
        /// <param name="castTime">The cast time of the spell.</param>
        public Rupture(int damage, float radius, float castTime) : base(damage, castTime) => this.radius = radius;

        /// <summary>
        /// Initializes the rupture spell with base configuration values.
        /// </summary>
        public Rupture() : this(SpellConfig.BASE_RUPTURE_DAMAGE, SpellConfig.BASE_RUPTURE_RADIUS, SpellConfig.BASE_RUPTURE_CAST_TIME)
        {

        }

        ///<inheritdoc/>
        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            /* Spawn rupture object underneath target actor. */
        }

        ///<inheritdoc/>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
        }
    }
}
