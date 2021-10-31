namespace BWolf.Patterns.Decorator
{

    public class FireBallExplosionUpgrade : SpellUpgrade
    {
        public FireBallExplosionUpgrade(Spell spell) : base(spell) { }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            EnsureRootSpell<FireBall>();

            caster.CastSpell(SpellType.FIRE_BALL_EXPLOSION, target);

            base.OnHit(caster, target);
        }
    }
}
