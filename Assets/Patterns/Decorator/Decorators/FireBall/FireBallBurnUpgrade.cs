namespace BWolf.Patterns.Decorator
{

    public class FireBallBurnUpgrade : SpellUpgrade
    {
        public int damage;

        public float time;

        public float frequency;

        public FireBallBurnUpgrade(Spell spell, int damage, float time, float frequency) : base(spell)
        {
            this.damage = damage;
            this.time = time;
            this.frequency = frequency;
        }

        public FireBallBurnUpgrade(Spell spell) : this(spell,
            SpellUpgradeConfig.FIRE_BALL_BURN_DAMAGE,
            SpellUpgradeConfig.FIRE_BALL_BURN_TIME,
            SpellUpgradeConfig.FIRE_BALL_BURN_FREQUENCY)
        {

        }

        public override void OnHit(ActorBehaviour caster, ActorBehaviour target)
        {
            EnsureRootSpell<FireBall>();

            target.AddDamageStatus(time, frequency, damage);

            base.OnHit(caster, target);
        }
    }
}
