using BWolf.Patterns.Decorator.EmbeddedPaterns.Factory;
using System;
using System.Collections.Generic;

namespace BWolf.Patterns.Decorator.EmbeddedPaterns.Builder
{
    /// <summary>
    /// Provides an interface with which a spell can be created using multiple upgrades.
    /// </summary>
    public class SpellBuilder
    {
        /// <summary>
        /// The root spell.
        /// </summary>
        private Spell _spell;

        /// <summary>
        /// The upgrades used for the spell.
        /// </summary>
        private List<Func<Spell,Spell>> _upgrades;

        /// <summary>
        /// Creates a new builder instance with a given spell.
        /// </summary>
        /// <param name="spell">The spell to build.</param>
        public SpellBuilder(Spell spell)
        {
            _spell = spell;
            _upgrades = new List<Func<Spell, Spell>>();
        }

        /// <summary>
        /// Creates a new builder instance with a given spell.
        /// </summary>
        /// <param name="spellType">The spell type to build.</param>
        public SpellBuilder(SpellType spellType) : this(SpellFactory.Create(spellType))
        {
        }

        /// <summary>
        /// Upgrades a spell using the decorator pattern.
        /// </summary>
        /// <param name="upgrade">The upgrade method.</param>
        /// <returns>The builder instance.</returns>
        public SpellBuilder Upgrade(Func<Spell, Spell> upgrade)
        {
            _upgrades.Add(upgrade);
            return this;
        }

        /// <summary>
        /// Upgrades a spell using the decorator pattern.
        /// </summary>
        /// <param name="upgrade">The upgrade type.</param>
        /// <returns>The builder instance.</returns>
        public SpellBuilder Upgrade(SpellUpgradeType upgrade) => Upgrade((spell) => SpellUpgradeFactory.Create(spell, upgrade));

        /// <summary>
        /// Builds the spell returning the spell with all its upgrades integrated.
        /// </summary>
        /// <returns>The build spell.</returns>
        public Spell Build()
        {
            if (_spell == null)
                throw new ArgumentNullException(nameof(Spell));

            foreach (Func<Spell, Spell> upgrade in _upgrades)
                _spell = upgrade(_spell);

            return _spell;
        }

        /// <summary>
        /// Implicitly converts a spell builder instance to a spell.
        /// </summary>
        /// <param name="builder">The spell builder instance.</param>
        public static implicit operator Spell(SpellBuilder builder) => builder.Build();
    }
}