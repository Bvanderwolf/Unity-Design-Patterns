namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// A spell upgrade that decreases the time to cast the spell.
    /// </summary>
    public class CastTimeDecreaseUpgrade : SpellUpgrade
    {
        /// <summary>
        /// The decrease in cast time percentage wise.
        /// </summary>
        public float castTimeDecrease;

        /// <summary>
        /// Initializes the upgrade with the spell it is decorating
        /// and the cast time decrease.
        /// </summary>
        /// <param name="spell">The spell it is decorating.</param>
        /// <param name="decrease">The decrease in cast time percentage wise.</param>
        public CastTimeDecreaseUpgrade(Spell spell, float decrease) : base(spell, decrease) => this.castTimeDecrease = decrease;

        public CastTimeDecreaseUpgrade(Spell spell) : this(spell, SpellUpgradeConfig.CAST_TIME_DECREASE)
        {
        }

        /// <summary>
        /// Decreases the cast time of the spell.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            Spell spell = GetRootSpell();
            spell.castTime *= (1f - castTimeDecrease);

            base.OnCast(caster, target);
        }
    }
}
