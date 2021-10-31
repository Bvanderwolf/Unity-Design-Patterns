using System;
using System.Collections.Generic;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Holds constants that store the base values for spells. 
    /// </summary>
    public static class SpellConfig
    {
        public static readonly Dictionary<Type, SpellType> typeMap = new Dictionary<Type, SpellType>
        {
            { typeof(FireBall), SpellType.FIRE_BALL },
            { typeof(FireBallExplosion), SpellType.FIRE_BALL_EXPLOSION },
            { typeof(Heal), SpellType.HEAL },
            { typeof(Poison), SpellType.POISON },
            { typeof(Rupture), SpellType.RUPTURE }
        };

        /* FIREBALL*/
        public const int BASE_FIREBALL_DAMAGE               = 5;
        public const float BASE_FIREBALL_SPEED              = 50.0f;
        public const float BASE_FIREBALL_CAST_TIME          = 1f;

        /* FIREBALL EXPLOSION */
        public const int BASE_FIREBALL_EXPLOSION_DAMAGE     = 5;
        public const float BASE_FIREBALL_EXPLOSION_RADIUS   = 25f;

        /* POISON */
        public const int BASE_POISON_DAMAGE                 = 8;
        public const float BASE_POISON_CAST_TIME            = 1f;
        public const float BASE_POISON_TIME                 = 3f;
        public const float BASE_POISON_FREQUENCY            = 0.5f;

        /* HEAL */
        public const int BASE_HEAL_AMOUNT                   = 10;
        public const float BASE_HEAL_CAST_TIME              = 2f;
        public const float BASE_HEAL_FREQUENCY              = 0.5f;

        /* RUPTURE */
        public const int BASE_RUPTURE_DAMAGE                = 10;
        public const float BASE_RUPTURE_RADIUS              = 25f;
        public const float BASE_RUPTURE_CAST_TIME           = 2.5f;
    }
}
