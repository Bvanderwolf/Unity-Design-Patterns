namespace BWolf.Patterns.Decorator
{
    public class Rupture : DamageSpell
    {
        public float radius;

        public Rupture(int damage, float radius, float castTime) : base(damage, castTime) => this.radius = radius;

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {

        }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {

        }
    }
}
