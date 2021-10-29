namespace BWolf.Patterns.Decorator
{

    public abstract class DamageSpell : Spell
    {
        public int damage;

        public DamageSpell(int damage, float? castTime) : base(castTime) => this.damage = damage;

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target) { }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target) { }
    }
}
