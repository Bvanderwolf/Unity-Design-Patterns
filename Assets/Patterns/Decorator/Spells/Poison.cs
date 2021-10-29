namespace BWolf.Patterns.Decorator
{
    public class Poison : DamageSpell
    {
        public float time;

        // todo: decorator more time but more damage

        public Poison(int damage, float time, float castTime) : base(damage, castTime) => this.time = time;

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {

        }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {

        }
    }
}