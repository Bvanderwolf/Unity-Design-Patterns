namespace BWolf.Patterns.Decorator
{
    public class FireBall : DamageSpell
    {

        public float speed;

        public FireBall(int damage, float speed, float castTime) : base(damage, castTime) => this.speed = speed;

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {

        }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {

        }
    }
}
