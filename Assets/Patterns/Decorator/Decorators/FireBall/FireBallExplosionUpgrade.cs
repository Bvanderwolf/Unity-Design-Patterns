namespace BWolf.Patterns.Decorator
{

    public class FireBallExplosionUpgrade : SpellUpgrade
    {
        public FireBallExplosionUpgrade(Spell spell) : base(spell) { }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            FireBall fireBall = p_spell as FireBall;
            if (fireBall == null)
                throw new IncompatibleUpgradeException(typeof(FireBall).Name, p_spell.GetType().Name);

            caster.CastSpell(SpellType.FIRE_BALL_EXPLOSION, target);

            base.OnHit(caster, target);
        }
    }
}
