using UnityEngine;

namespace BWolf.Patterns.Decorator
{

    public class DamageIncreaseUpgrade : SpellUpgrade
    {
        public float damageIncrease;

        public DamageIncreaseUpgrade(Spell spell, float damageIncrease) : base(spell) => this.damageIncrease = damageIncrease;

        public DamageIncreaseUpgrade(Spell spell) : this(spell, SpellUpgradeConfig.DAMAGE_INCREASE)
        {
        }

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            DamageSpell damageSpell = GetRootSpell<DamageSpell>();
            damageSpell.damage = Mathf.RoundToInt(damageSpell.damage * damageIncrease);

            base.OnCast(caster, target);
        }
    }
}