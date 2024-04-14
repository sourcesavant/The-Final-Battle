namespace TheFinalBattle;

public class BoneCrunch : Attack
{
    public static new string AttackName { get; } = "BONE CRUNCH";

    public BoneCrunch(Character source, Character target) : base(source, target) { }

    protected override int GetDamage()
    {
        Random random = new Random();
        return random.Next(2);
    }
}
