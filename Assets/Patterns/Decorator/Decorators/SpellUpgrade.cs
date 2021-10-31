namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Acts as a decorator to add additional features to a spell.
    /// </summary>
    public class SpellUpgrade : Spell
    {
        /// <summary>
        /// The next spell in the decorator chain.
        /// </summary>
        private Spell p_next;

        /// <summary>
        /// The original spell at the root of the decorator chain.
        /// </summary>
        private readonly Spell _root;

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
                spell = upgrade._root;

            // Store the original spell.
            _root = spell;
        }

        /// <inheritdoc/>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target) => p_next.Cast(caster, target);

        /// <inheritdoc/>
        public override void OnHit(ActorBehaviour caster, ActorBehaviour target) => _root.OnHit(caster, target);

        /// <summary>
        /// Ensures the root spell is compatible with a spell type.
        /// </summary>
        /// <typeparam name="T">The spell type to ensure.</typeparam>
        protected void EnsureRootSpell<T>() where T : Spell
        {
            if (!(_root is T))
                throw new IncompatibleUpgradeException(typeof(T).Name, _root.GetType().Name);
        }

        /// <summary>
        /// Returns the root spell as a specified spell type.
        /// </summary>
        /// <typeparam name="T">The spell type to return the spell as.</typeparam>
        /// <returns>The spell of specified type.</returns>
        protected T GetRootSpell<T>() where T : Spell
        {
            T spell = _root as T;
            if (spell == null)
                throw new IncompatibleUpgradeException(typeof(T).Name, _root.GetType().Name);

            return spell;
        }

        /// <summary>
        /// Returns the root spell.
        /// </summary>
        /// <returns>The root spell.</returns>
        protected Spell GetRootSpell() => _root;
    }
}