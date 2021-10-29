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
        /// Applies the heal increase and set the new time in which the heal is applied.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            Heal heal = p_spell as Heal;
            if (heal == null)
                throw new IncompatibleUpgradeException(typeof(Heal).Name, p_spell.GetType().Name);

            heal.amount = Mathf.RoundToInt(heal.amount * healIncrease);
            heal.time = time;

            base.OnCast(caster, target);
        }
    }
}
