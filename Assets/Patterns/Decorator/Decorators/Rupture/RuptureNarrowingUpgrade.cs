using UnityEngine;

namespace BWolf.Patterns.Decorator
{
    public class RuptureNarrowingUpgrade : SpellUpgrade
    {
        public float damageIncrease;

        public float radiusIncrease;

        public RuptureNarrowingUpgrade(Spell spell, float damageIncrease, float radiusDecrease) : base(spell)
        {
            this.damageIncrease = damageIncrease;
            this.radiusIncrease = radiusDecrease;
        }

        public RuptureNarrowingUpgrade(Spell spell) : this(spell,
            SpellUpgradeConfig.RUPTURE_NARROWING_DAMAGE_INCREASE,
            SpellUpgradeConfig.RUPTURE_NARROWING_RADIUS_DECREASE)
        {

        }

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            Rupture rupture  = GetRootSpell<Rupture>();
            rupture.damage = Mathf.RoundToInt(rupture.damage * damageIncrease);
            rupture.radius *= (1f - radiusIncrease);

            base.OnCast(caster, target);
        }
    }
}