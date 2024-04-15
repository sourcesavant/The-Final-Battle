namespace TheFinalBattle;

public class Unraveling : Attack
{
    public override string AttackName { get; } = "UNRAVELING ATTACK";

    public Unraveling(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        Random random = new Random();
        return random.Next(3);
    }
}
