namespace BWolf.Patterns.Decorator
{


    public class FireBallExplosion : DamageSpell
    {
        public float radius;

        public FireBallExplosion(int damage, float radius, float castTime) : base(damage, castTime) => this.radius = radius;

        public override void OnCast(ActorBehaviour caster, ActorBehaviour target)
        {
            /* Spawn cool fire ball explosion at actor location. */

            base.OnCast(caster, target);
        }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            target.Damage(damage);

            base.OnHit(caster, target);
        }
    }
}
