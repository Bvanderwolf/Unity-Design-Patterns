namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Holds constants that store the base values for spells. 
    /// </summary>
    public static class SpellConfig
    {
        /* FIREBALL*/
        public const int BASE_FIREBALL_DAMAGE       = 5;
        public const float BASE_FIREBALL_SPEED      = 50.0f;
        public const float BASE_FIREBALL_CAST_TIME  = 1f;

        /* POISON */
        public const int BASE_POISON_DAMAGE         = 8;
        public const float BASE_POISON_CAST_TIME    = 1f;
        public const float BASE_POISON_TIME         = 3f;

        /* HEAL */
        public const int BASE_HEAL_AMOUNT           = 10;
        public const float BASE_HEAL_CAST_TIME      = 2f;
        public const float BASE_HEAL_FREQUENCY      = 0.5f;

        /* RUPTURE */
        public const int BASE_RUPTURE_DAMAGE        = 10;
        public const float BASE_RUPTURE_RADIUS      = 25f;
        public const float BASE_RUPTURE_CAST_TIME   = 2.5f;
    }
}
