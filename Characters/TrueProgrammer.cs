namespace TheFinalBattle;

public class TrueProgrammer : Hero
{
    public override string Name { get; }
    public override int MaxHP { get; } = 25;

    public TrueProgrammer(string name)
    {
        Name = name;
    }
}
