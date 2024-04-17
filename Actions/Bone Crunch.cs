namespace TheFinalBattle;

public class BoneCrunch : Attack
{
    public override string AttackName { get; } = "BONE CRUNCH";

    public BoneCrunch(Character source, Character target) : base(source, target) { }

    protected override int CalculateDamage()
    {
        Random random = new Random();
        return random.Next(2);
    }
}
