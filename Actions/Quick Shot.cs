namespace TheFinalBattle;

/// <summary>
/// Quick shot attack. Deals 3 damage with a 25% hit chance.
/// </summary>
public class QuickShot : Attack
{
    public override string AttackName { get; } = "QUICK SHOT";

    protected override double _hitChance { get; } = 0.25;

    public QuickShot(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        return 3;
    }
}
