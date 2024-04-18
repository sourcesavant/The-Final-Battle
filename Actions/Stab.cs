namespace TheFinalBattle;

/// <summary>
/// Stab attack. Deals 2 damage.
/// </summary>
public class Stab : Attack
{
    public override string AttackName { get; } = "STAB";

    public Stab(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        return 2;
    }
}
