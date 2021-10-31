using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Upgrades a healing spell with an increased heal amount but
    /// makes it applicable over time.
    /// </summary>
    public class HealOverTimeUpgrade : SpellUpgrade
    {
        /// <summary>
        /// The heal increase percentage wise.
        /// </summary>
        public float healIncrease;

        /// <summary>
        /// The time in which the heal is applied.
        /// </summary>
        public float time;

        /// <summary>
        /// Initializes the upgrade with the spell it is decorating,
        /// the heal increase and the new time in which the heal is applied.
        /// </summary>
        /// <param name="spell">The spell it is decorating.</param>
        /// <param name="healIncrease">The heal increase.</param>
        /// <param name="time">The time in which the heal is applied.</param>
        public HealOverTimeUpgrade(Spell spell, float healIncrease, float time) : base(spell)
        {
            this.healIncrease = healIncrease;
            this.time = time;
        }

        /// <summary>
        /// Initializes the upgrade with base configuration values.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        public HealOverTimeUpgrade(Spell spell) : this(spell,
            SpellUpgradeConfig.HEAL_OVER_TIME_HEAL_INCREASE,
            SpellUpgradeConfig.HEAL_OVER_TIME_HEAL_TIME)
        {

        }

        /// <summary>
        /// Applies the heal increase and set the new time in which the heal is applied.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target)
        {
            Heal heal = GetRootSpell<Heal>();
            heal.amount = Mathf.RoundToInt(heal.amount * healIncrease);
            heal.time = time;

            base.Cast(caster, target);
        }
    }
}
