using UnityEngine;

namespace BWolf.Patterns.Decorator
{

    public class PoisonDamageOverTime : SpellUpgrade
    {
        public float damageIncrease;

        public float timeIncrease;

        public PoisonDamageOverTime(Spell spell, float damageIncrease, float timeIncrease) : base(spell)
        {
            this.damageIncrease = damageIncrease;
            this.timeIncrease = timeIncrease;
        }

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            Poison poison = p_spell as Poison;
            if (poison == null)
                throw new IncompatibleUpgradeException(typeof(Poison).Name, p_spell.GetType().Name);

            poison.damage = Mathf.RoundToInt(poison.damage * damageIncrease);
            poison.time *= timeIncrease;

            base.OnCast(caster, target);
        }
    }
}
