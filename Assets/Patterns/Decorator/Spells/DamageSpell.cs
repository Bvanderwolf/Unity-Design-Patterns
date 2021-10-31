namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Represents a spell that deals damage to a target actor.
    /// </summary>
    public abstract class DamageSpell : Spell
    {
        /// <summary>
        /// The damage to deal.
        /// </summary>
        public int damage;

        /// <summary>
        /// Initializes the damage spell with values for its internal state.
        /// </summary>
        /// <param name="damage">the damage to deal.</param>
        /// <param name="castTime">The cast time of the spell.</param>
        public DamageSpell(int damage, float? castTime) : base(castTime) => this.damage = damage;

        ///<inheritdoc/>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target) { }

        ///<inheritdoc/>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target) { }

        ///<inheritdoc/>
        public override void Reset()
        {
            base.Reset();

            this.damage = 0;
        }
    }
}
