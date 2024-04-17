namespace TheFinalBattle;

public class QuickShot : Attack
{
    public override string AttackName { get; } = "QUICK SHOT";

    protected override double _hitChance { get; } = 0.5;

    public QuickShot(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        return 3;
    }
}
