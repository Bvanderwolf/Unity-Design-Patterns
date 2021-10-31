using BWolf.Patterns.Decorator.EmbeddedPaterns.Pooling;
using System;
using System.Collections.Generic;

namespace BWolf.Patterns.Decorator.EmbeddedPaterns.Factory
{
    /// <summary>
    /// Provide methods for creation of spells with upgrades.
    /// </summary>
    public static class SpellFactory
    {
        /// <summary>
        /// Creates a new spell with upgrades.
        /// </summary>
        /// <param name="spellType">The spell type.</param>
        /// <param name="upgrades">The upgrades to use for the spell.</param>
        /// <returns>The created spell.</returns>
        public static Spell Create(SpellType spellType, List<SpellUpgradeType> upgrades)
        {
            Spell spell = SpellPool.Retrieve(spellType);
            return ApplyUpgrades(spell, upgrades);
        }

        /// <summary>
        /// Creates a new spell without upgrades.
        /// </summary>
        /// <param name="spellType">The spell type.</param>
        /// <returns>The created spell.</returns>
        public static Spell Create(SpellType spellType) => Create(spellType, new List<SpellUpgradeType>());

        /// <summary>
        /// Creates a new instance of a spell without upgrades.
        /// </summary>
        /// <param name="spellType">The spell type.</param>
        /// <returns>The new spell instance.</returns>
        internal static Spell CreateNew(SpellType spellType)
        {
            switch (spellType)
            {
                case SpellType.FIRE_BALL:
                    return new FireBall();

                case SpellType.HEAL:
                    return new Heal();

                case SpellType.RUPTURE:
                    return new Rupture();

                case SpellType.POISON:
                    return new Poison();

                case SpellType.FIRE_BALL_EXPLOSION:
                    return new FireBallExplosion();

                default:
                    throw new NotImplementedException($"Spell with type {spellType} has not yet been implemented.");
            }
        }

        /// <summary>
        /// Applies upgrades to a spell. 
        /// </summary>
        /// <param name="spell">The spell to apply the upgrades to.</param>
        /// <param name="upgrades">The upgrades to apply.</param>
        /// <returns>The spell with applied upgrades.</returns>
        private static Spell ApplyUpgrades(Spell spell, List<SpellUpgradeType> upgrades)
        {
            for (int i = 0; i < upgrades.Count; i++)
                spell = SpellUpgradeFactory.Create(spell, upgrades[i]);

            return spell;
        }
    }
}