namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// The types of upgrades for a spell.
    /// </summary>
    public enum SpellUpgradeType
    {
        HEAL_OVER_TIME              = 0,
        CAST_TIME_DECREASE          = 1,
        HEAL_INCREASE               = 2,
        POISON_DAMAGE_OVER_TIME     = 3,
        DAMAGE_INCREASE             = 4,
        RUPTURE_NARROW_DAMAGE       = 5,
        FIRE_BALL_BURN              = 6,
        FIRE_BALL_EXPLOSION         = 7,
    }
}