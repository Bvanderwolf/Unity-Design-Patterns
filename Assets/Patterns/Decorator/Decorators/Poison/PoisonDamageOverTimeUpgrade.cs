using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// A spell that upgrades a <see cref="Poison"/> spell to do more damage but take longer.
    /// </summary>
    public class PoisonDamageOverTimeUpgrade : SpellUpgrade
    {
        /// <summary>
        /// The damage increase.
        /// </summary>
        public float damageIncrease;

        /// <summary>
        /// The time increase.
        /// </summary>
        public float timeIncrease;

        /// <summary>
        /// Initializes the spell upgrade with values to set its internal state.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        /// <param name="damageIncrease">The damage increase.</param>
        /// <param name="timeIncrease">The time increase.</param>
        public PoisonDamageOverTimeUpgrade(Spell spell, float damageIncrease, float timeIncrease) : base(spell)
        {
            this.damageIncrease = damageIncrease;
            this.timeIncrease = timeIncrease;
        }

        /// <summary>
        /// Initializes the spell upgrade with base configuration values.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        public PoisonDamageOverTimeUpgrade(Spell spell) : this(spell,
            SpellUpgradeConfig.POISON_OVER_TIME_DAMAGE_INCREASE,
            SpellUpgradeConfig.POISON_OVER_TIME_DAMAGE_TIME_INCREASE)
        {

        }

        /// <summary>
        /// Increases both damage and time of the poison spell.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target)
        {
            Poison poison = GetRootSpell<Poison>();
            poison.damage = Mathf.RoundToInt(poison.damage * damageIncrease);
            poison.time *= timeIncrease;

            base.Cast(caster, target);
        }
    }
}
