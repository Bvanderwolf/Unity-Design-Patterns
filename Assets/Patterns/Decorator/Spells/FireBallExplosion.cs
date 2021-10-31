namespace BWolf.Patterns.Decorator
{

    /// <summary>
    /// Represents an explosion of fire damaging nearby actors.
    /// </summary>
    public class FireBallExplosion : DamageSpell
    {
        /// <summary>
        /// The radius of the explosion.
        /// </summary>
        public float radius;

        /// <summary>
        /// Initializes the fire ball explosion with values for its internal state.
        /// </summary>
        /// <param name="damage">The explosion damage.</param>
        /// <param name="radius">The explosion radius.</param>
        /// <param name="castTime">The spell cast time.</param>
        public FireBallExplosion(int damage, float radius, float castTime) : base(damage, castTime) => this.radius = radius;

        /// <summary>
        /// Initializes the fire ball explosion with base configuration values.
        /// </summary>
        public FireBallExplosion() : this(SpellConfig.BASE_FIREBALL_EXPLOSION_DAMAGE, SpellConfig.BASE_FIREBALL_EXPLOSION_RADIUS, 0.0f)
        {
        }

        ///<inheritdoc/>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target)
        {
            /* Spawn cool fire ball explosion at actor location. */

            base.Cast(caster, target);
        }

        ///<inheritdoc/>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            target.Damage(damage);

            base.OnHit(caster, target);
        }

        ///<inheritdoc/>
        public override void Reset()
        {
            base.Reset();

            this.radius = 0;
        }

        ///<inheritdoc/>
        public override void SetBaseValues()
        {
            base.SetBaseValues();

            this.radius = SpellConfig.BASE_FIREBALL_EXPLOSION_RADIUS;
            this.damage = SpellConfig.BASE_FIREBALL_EXPLOSION_DAMAGE;
        }
    }
}
