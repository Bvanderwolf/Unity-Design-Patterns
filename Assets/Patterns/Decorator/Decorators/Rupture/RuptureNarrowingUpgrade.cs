using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    /// <summary>
    /// A spell upgrade that narrows the radius of a <see cref="Rupture"/> spell but increases its damage.
    /// </summary>
    public class RuptureNarrowingUpgrade : SpellUpgrade
    {
        /// <summary>
        /// The damage increase.
        /// </summary>
        public float damageIncrease;

        /// <summary>
        /// The radius decrease. 
        /// </summary>
        public float radiusDecrease;

        /// <summary>
        /// Initializes the spell upgrade with values to set its internal state.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        /// <param name="damageIncrease">The damage increase.</param>
        /// <param name="radiusDecrease">The radius decrease.</param>
        public RuptureNarrowingUpgrade(Spell spell, float damageIncrease, float radiusDecrease) : base(spell)
        {
            this.damageIncrease = damageIncrease;
            this.radiusDecrease = radiusDecrease;
        }

        /// <summary>
        /// Initializes the spell upgrade with base configuration values.
        /// </summary>
        /// <param name="spell">The spell to upgrade.</param>
        public RuptureNarrowingUpgrade(Spell spell) : this(spell,
            SpellUpgradeConfig.RUPTURE_NARROWING_DAMAGE_INCREASE,
            SpellUpgradeConfig.RUPTURE_NARROWING_RADIUS_DECREASE)
        {

        }

        /// <summary>
        /// Increases the damage and reduces the radius of the rupture spell.
        /// </summary>
        /// <param name="caster">The casting actor.</param>
        /// <param name="target">The target actor.</param>
        public override void Cast(ActorBehaviour caster, ActorBehaviour target)
        {
            Rupture rupture  = GetRootSpell<Rupture>();
            rupture.damage = Mathf.RoundToInt(rupture.damage * damageIncrease);
            rupture.radius *= (1f - radiusDecrease);

            base.Cast(caster, target);
        }
    }
}