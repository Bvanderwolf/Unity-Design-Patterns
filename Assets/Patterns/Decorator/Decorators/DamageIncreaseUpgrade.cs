using UnityEngine;

namespace BWolf.Patterns.Decorator
{

    public class DamageIncreaseUpgrade : SpellUpgrade
    {
        public float damageIncrease;

        public DamageIncreaseUpgrade(Spell spell, float damageIncrease) : base(spell) => this.damageIncrease = damageIncrease;

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            DamageSpell damageSpell = p_spell as DamageSpell;
            if (damageSpell == null)
                throw new IncompatibleUpgradeException(typeof(DamageSpell).Name, p_spell.GetType().Name);

            damageSpell.damage = Mathf.RoundToInt(damageSpell.damage * damageIncrease);

            base.OnCast(caster, target);
        }
    }
}