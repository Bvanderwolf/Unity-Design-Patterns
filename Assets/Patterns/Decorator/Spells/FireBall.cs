namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Represents a spell that spawns a fire ball object that damages 
    /// a target actor on hit.
    /// </summary>
    public class FireBall : DamageSpell
    {
        /// <summary>
        /// The speed with which to throw the fireball.
        /// </summary>
        public float speed;

        /// <summary>
        /// Initializes the fireball spell with values for its internal state.
        /// </summary>
        /// <param name="damage">The damage the rupture will do.</param>
        /// <param name="speed">The speed with which to throw the fireball.</param>
        /// <param name="castTime">The cast time of the spell.</param>
        public FireBall(int damage, float speed, float castTime) : base(damage, castTime) => this.speed = speed;

        /// <summary>
        /// Initializes the fireball with base configuration values.
        /// </summary>
        public FireBall() : this(SpellConfig.BASE_FIREBALL_DAMAGE, SpellConfig.BASE_FIREBALL_SPEED, SpellConfig.BASE_FIREBALL_CAST_TIME)
        {
        }

        ///<inheritdoc/>
        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            /* Throw fireball object towards the target actor. */
        }

        ///<inheritdoc/>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            target.Damage(damage);
        }
    }
}
