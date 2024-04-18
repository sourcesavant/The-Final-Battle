namespace TheFinalBattle;

/// <summary>
/// Slash attack. Deals 2 damage.
/// </summary>
public class Slash : Attack
{
    public override string AttackName { get; } = "SLASH";

    public Slash(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        return 2;
    }
}
