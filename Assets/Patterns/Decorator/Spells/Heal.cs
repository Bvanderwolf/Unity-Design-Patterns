namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Represents a spell that can heal an actor.
    /// </summary>
    public class Heal : Spell
    {
        /// <summary>
        /// The amount to heal.
        /// </summary>
        public int amount;

        /// <summary>
        /// The time in which the heal is applied.
        /// <para>Used for heal over time effects.</para>
        /// </summary>
        public float time;

        /// <summary>
        /// The frequency with which the heal is applied.
        /// <para>Used for heal over time effects.</para>
        /// </summary>
        public float frequency;

        /// <summary>
        /// Initializes the heal spell with an amount and cast time.
        /// </summary>
        /// <param name="amount">The amount to heal.</param>
        /// <param name="castTime">The time it takes to cast the spell.</param>
        public Heal(int amount, float castTime) : base(castTime)
        {
            this.amount = amount;
            this.time = 0.0f;
            this.frequency = 0.0f;
        }

        /// <summary>
        /// Initializes the heal spell with base configuration values.
        /// </summary>
        public Heal() : this(SpellConfig.BASE_HEAL_AMOUNT, SpellConfig.BASE_HEAL_CAST_TIME)
        {
        }

        /// <summary>
        /// Casts the heal, healing the target actor instantly if no time is used
        /// or adding a heal status if time has been set.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            if (time != 0)
                target.Heal(amount);
            else
                target.AddHealStatus(time, frequency, amount);
        }

        /// <summary>
        /// Has no implementation yet.
        /// </summary>
        /// <param name="target">The target actor.</param>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target) { }
    }
}
