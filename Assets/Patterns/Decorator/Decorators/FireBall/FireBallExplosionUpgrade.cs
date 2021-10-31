namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// A spell upgrade that creates a fire explosion after the actor has been hit with a <see cref="FireBall"/> spell.
    /// </summary>
    public class FireBallExplosionUpgrade : SpellUpgrade
    {
        /// <summary>
        /// Initializes the internal state of the upgrade.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        public FireBallExplosionUpgrade(Spell spell) : base(spell) { }

        /// <summary>
        /// Makes the caster cast the fire ball explosion spell.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            EnsureRootSpell<FireBall>();

            caster.CastSpell(SpellType.FIRE_BALL_EXPLOSION, target);

            base.OnHit(caster, target);
        }
    }
}
