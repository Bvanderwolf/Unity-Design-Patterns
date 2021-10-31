using BWolf.Patterns.Decorator.EmbeddedPaterns.Pooling;
using System;

namespace BWolf.Patterns.Decorator.EmbeddedPaterns.Factory
{
    /// <summary>
    /// Provides methods for creation of spell upgrades.
    /// </summary>
    public static class SpellUpgradeFactory
    {
        /// <summary>
        /// Creates a new spell upgrade using a given spell to decorate.
        /// </summary>
        /// <param name="spell">The spell this upgrade is decorating.</param>
        /// <param name="type">The spell upgrade type.</param>
        /// <returns>The spell upgrade.</returns>
        public static SpellUpgrade Create(Spell spell, SpellUpgradeType type) => SpellPool.Retrieve(spell, type);

        internal static SpellUpgrade CreateNew(Spell spell, SpellUpgradeType type)
        {
            switch (type)
            {
                case SpellUpgradeType.HEAL_OVER_TIME:
                    return new HealOverTimeUpgrade(spell);

                case SpellUpgradeType.CAST_TIME_DECREASE:
                    return new CastTimeDecreaseUpgrade(spell);

                case SpellUpgradeType.HEAL_INCREASE:
                    return new HealIncreaseUpgrade(spell);

                case SpellUpgradeType.DAMAGE_INCREASE:
                    return new DamageIncreaseUpgrade(spell);

                case SpellUpgradeType.FIRE_BALL_EXPLOSION:
                    return new FireBallExplosionUpgrade(spell);

                case SpellUpgradeType.POISON_DAMAGE_OVER_TIME:
                    return new PoisonDamageOverTimeUpgrade(spell);

                case SpellUpgradeType.FIRE_BALL_BURN:
                    return new FireBallBurnUpgrade(spell);

                case SpellUpgradeType.RUPTURE_NARROW_DAMAGE:
                    return new RuptureNarrowingUpgrade(spell);

                default:
                    throw new NotImplementedException($"Spell upgrade with type {type} has not yet been implemented.");
            }
        }
    }
}