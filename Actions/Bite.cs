namespace TheFinalBattle;

/// <summary>
/// Bite attack. Deals 2 damage.
/// </summary>
public class Bite : Attack
{
    public override string AttackName { get; } = "BITE";

    public Bite(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage() => 2;
}
