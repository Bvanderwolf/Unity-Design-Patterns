using System;

namespace BWolf.Patterns.Decorator.EmbeddedPaterns.Factory
{
    public static class SpellUpgradeFactory
    {
        public static SpellUpgrade Create(Spell spell, SpellUpgradeType type)
        {
            switch (type)
            {
                case SpellUpgradeType.HEAL_OVER_TIME:
                    return new HealOverTimeUpgrade(
                        spell,
                        SpellUpgradeConfig.HEAL_OVER_TIME_HEAL_INCREASE,
                        SpellUpgradeConfig.HEAL_OVER_TIME_HEAL_TIME
                    );

                case SpellUpgradeType.CAST_TIME_DECREASE:
                    return new CastTimeDecreaseUpgrade(
                        spell,
                        SpellUpgradeConfig.CAST_TIME_DECREASE
                    );

                case SpellUpgradeType.HEAL_INCREASE:
                    return new HealIncreaseUpgrade(
                        spell,
                        SpellUpgradeConfig.HEAL_INCREASE
                    );

                default:
                    throw new NotImplementedException($"Spell upgrade with type {type} has not yet been implemented.");
            }
        }
    }
}