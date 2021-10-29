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
            switch (spellType)
            {
                case SpellType.FIRE_BALL:
                    return ApplyUpgrades(new FireBall(
                        SpellConfig.BASE_FIREBALL_DAMAGE,
                        SpellConfig.BASE_FIREBALL_SPEED,
                        SpellConfig.BASE_FIREBALL_CAST_TIME
                    ), upgrades);

                case SpellType.HEAL:
                    return ApplyUpgrades(new Heal(
                        SpellConfig.BASE_HEAL_AMOUNT,
                        SpellConfig.BASE_HEAL_CAST_TIME
                    ), upgrades);

                case SpellType.RUPTURE:
                    return ApplyUpgrades(new Rupture(
                        SpellConfig.BASE_RUPTURE_DAMAGE,
                        SpellConfig.BASE_RUPTURE_RADIUS,
                        SpellConfig.BASE_RUPTURE_CAST_TIME
                    ), upgrades);

                case SpellType.POISON:
                    return ApplyUpgrades(new Poison(
                        SpellConfig.BASE_POISON_DAMAGE,
                        SpellConfig.BASE_POISON_TIME,
                        SpellConfig.BASE_POISON_CAST_TIME
                    ), upgrades);

                default:
                    throw new NotImplementedException($"Spell with type {spellType} has not yet been implemented.");
            }
        }

        /// <summary>
        /// Creates a new spell without upgrades.
        /// </summary>
        /// <param name="spellType">The spell type.</param>
        /// <returns>The created spell.</returns>
        public static Spell Create(SpellType spellType) => Create(spellType, new List<SpellUpgradeType>());

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