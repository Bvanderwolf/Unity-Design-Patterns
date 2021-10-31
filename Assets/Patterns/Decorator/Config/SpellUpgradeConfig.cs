using System;
using System.Collections.Generic;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Holds constants that store the values for spell upgrades. 
    /// </summary>
    public class SpellUpgradeConfig
    {
        public static readonly Dictionary<Type, SpellUpgradeType> typeMap = new Dictionary<Type, SpellUpgradeType>
        {
            { typeof(HealOverTimeUpgrade), SpellUpgradeType.HEAL_OVER_TIME },
            { typeof(HealIncreaseUpgrade), SpellUpgradeType.HEAL_INCREASE },
            { typeof(FireBallBurnUpgrade), SpellUpgradeType.FIRE_BALL_BURN },
            { typeof(FireBallExplosionUpgrade), SpellUpgradeType.FIRE_BALL_EXPLOSION },
            { typeof(PoisonDamageOverTimeUpgrade), SpellUpgradeType.POISON_DAMAGE_OVER_TIME },
            { typeof(RuptureNarrowingUpgrade), SpellUpgradeType.RUPTURE_NARROW_DAMAGE }
        };

        /* HEAL */
        public const float HEAL_OVER_TIME_HEAL_INCREASE             = 1.5f;
        public const float HEAL_OVER_TIME_HEAL_TIME                 = 1f;

        /* GENERAL */
        public const float CAST_TIME_DECREASE                       = 0.75f;
        public const float DAMAGE_INCREASE                          = 1.25f;
        public const float HEAL_INCREASE                            = 1.25f;

        /* FIREBALL */
        public const float FIRE_BALL_BURN_TIME                      = 1f;
        public const int FIRE_BALL_BURN_DAMAGE                      = 25;
        public const float FIRE_BALL_BURN_FREQUENCY                 = 0.5f;

        /* RUPTURE */
        public const float RUPTURE_NARROWING_DAMAGE_INCREASE        = 1.75f;
        public const float RUPTURE_NARROWING_RADIUS_DECREASE        = 0.75f;

        /* POISON */
        public const float POISON_OVER_TIME_DAMAGE_INCREASE         = 1.5f;
        public const float POISON_OVER_TIME_DAMAGE_TIME_INCREASE    = 1.5f;
    }
}
