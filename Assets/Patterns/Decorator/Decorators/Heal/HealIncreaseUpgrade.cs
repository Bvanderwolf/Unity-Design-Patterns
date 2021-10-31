using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// Upgrades a healing spell with an increased heal amount.
    /// </summary>
    public class HealIncreaseUpgrade : SpellUpgrade
    {
        /// <summary>
        /// The heal increase percentage wise.
        /// </summary>
        public float healIncrease;

        /// <summary>
        /// Initializes the upgrade with the spell it is decorating
        /// and the heal increase.
        /// </summary>
        /// <param name="spell">The spell it is decorating.</param>
        /// <param name="healIncrease">The heal increase percentage wise.</param>
        public HealIncreaseUpgrade(Spell spell, float healIncrease) : base(spell) => this.healIncrease = healIncrease;

        /// <summary>
        /// Initializes the upgrade with base configuration values.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        public HealIncreaseUpgrade(Spell spell) : this(spell, SpellUpgradeConfig.HEAL_INCREASE)
        {
        }

        /// <summary>
        /// Increases the heal amount before.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target)
        {
            Heal heal = GetRootSpell<Heal>();
            heal.amount = Mathf.RoundToInt(heal.amount * healIncrease);

            base.Cast(caster, target);
        }
    }
}