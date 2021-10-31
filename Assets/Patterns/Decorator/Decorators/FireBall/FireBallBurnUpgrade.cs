namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// A spell upgrade that sets an actor ablaze after it is hit with a <see cref="FireBall"/> spell.
    /// </summary>
    public class FireBallBurnUpgrade : SpellUpgrade
    {
        /// <summary>
        /// The burn damage.
        /// </summary>
        public int damage;

        /// <summary>
        /// The time for the burn to damage to.
        /// </summary>
        public float time;

        /// <summary>
        /// The frequency with which the burn will do damage.
        /// </summary>
        public float frequency;

        /// <summary>
        /// Initializes the spell upgrade with values to set its internal state.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        /// <param name="damage">The burn damage.</param>
        /// <param name="time">The time for the burn to damage to.</param>
        /// <param name="frequency">The frequency with which the burn will do damage.</param>
        public FireBallBurnUpgrade(Spell spell, int damage, float time, float frequency) : base(spell)
        {
            this.damage = damage;
            this.time = time;
            this.frequency = frequency;
        }

        /// <summary>
        /// Initializes the spell upgrade with base configuration values.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        public FireBallBurnUpgrade(Spell spell) : this(spell,
            SpellUpgradeConfig.FIRE_BALL_BURN_DAMAGE,
            SpellUpgradeConfig.FIRE_BALL_BURN_TIME,
            SpellUpgradeConfig.FIRE_BALL_BURN_FREQUENCY)
        {
        }

        /// <summary>
        /// Adds the burn damage status.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            EnsureRootSpell<FireBall>();

            target.AddDamageStatus(time, frequency, damage);

            base.OnHit(caster, target);
        }
    }
}
