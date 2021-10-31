using UnityEngine;

namespace BWolf.Patterns.Decorator
{

    public class PoisonDamageOverTimeUpgrade : SpellUpgrade
    {
        public float damageIncrease;

        public float timeIncrease;

        public PoisonDamageOverTimeUpgrade(Spell spell, float damageIncrease, float timeIncrease) : base(spell)
        {
            this.damageIncrease = damageIncrease;
            this.timeIncrease = timeIncrease;
        }

        public PoisonDamageOverTimeUpgrade(Spell spell) : this(spell,
            SpellUpgradeConfig.POISON_OVER_TIME_DAMAGE_INCREASE,
            SpellUpgradeConfig.POISON_OVER_TIME_DAMAGE_TIME_INCREASE)
        {

        }

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            Poison poison = GetRootSpell<Poison>();
            poison.damage = Mathf.RoundToInt(poison.damage * damageIncrease);
            poison.time *= timeIncrease;

            base.OnCast(caster, target);
        }
    }
}
