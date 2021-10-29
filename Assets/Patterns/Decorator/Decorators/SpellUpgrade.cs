namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Acts as a decorator to add additional features to a spell.
    /// </summary>
    public class SpellUpgrade : Spell
    {
        /// <summary>
        /// The original spell at the root of the decorator chain.
        /// </summary>
        protected Spell p_spell;

        /// <summary>
        /// The next spell in the decorator chain.
        /// </summary>
        private Spell p_next;

        /// <summary>
        /// Initializes the root and next spell in the decorator chain.
        /// </summary>
        /// <param name="spell">The spell to decorate.</param>
        /// <param name="castTime">The cast time to for the spell.</param>
        public SpellUpgrade(Spell spell, float? castTime = null) : base(castTime)
        {
            // Store the spell as upgrade. This will be null if it was the first upgrade added.
            p_next = spell;

            // Traverse towards the original spell at the root of the decorator chain.
            while (spell is SpellUpgrade upgrade)
                spell = upgrade.p_spell;

            // Store the original spell.
            p_spell = spell;
        }

        /// <inheritdoc/>
        public override void OnCast(ActorBehaviour caster, ActorBehaviour target) => p_next.OnCast(caster, target);

        /// <inheritdoc/>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target) => p_spell.OnHit(caster, target);
    }
}