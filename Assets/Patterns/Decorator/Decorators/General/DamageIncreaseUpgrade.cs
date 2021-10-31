using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// A spell upgrade that increases the damage for a <see cref="DamageSpell"/>.
    /// </summary>
    public class DamageIncreaseUpgrade : SpellUpgrade
    {
        /// <summary>
        /// The damage increase.
        /// </summary>
        public float damageIncrease;

        /// <summary>
        /// Initializes the upgrade with values to set its internal state.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        /// <param name="damageIncrease">The damage increase.</param>
        public DamageIncreaseUpgrade(Spell spell, float damageIncrease) : base(spell) => this.damageIncrease = damageIncrease;

        /// <summary>
        /// Initializes the upgrade with base configuration values.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        public DamageIncreaseUpgrade(Spell spell) : this(spell, SpellUpgradeConfig.DAMAGE_INCREASE)
        {
        }

        /// <summary>
        /// Increases the damage the spell will do.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target)
        {
            DamageSpell damageSpell = GetRootSpell<DamageSpell>();
            damageSpell.damage = Mathf.RoundToInt(damageSpell.damage * damageIncrease);

            base.Cast(caster, target);
        }
    }
}