namespace TheFinalBattle;

public class Stab : Attack
{
    public override string AttackName { get; } = "STAB";

    public Stab(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        return 1;
    }
}
