namespace TheFinalBattle;

public class Bite : Attack
{
    public override string AttackName { get; } = "BITE";

    public Bite(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage() => 1;
}
