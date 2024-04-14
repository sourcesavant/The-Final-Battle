namespace TheFinalBattle;

public class Punch : Attack
{
    public static new string AttackName { get; } = "PUNCH";
    
    public Punch(Character source, Character target) : base(source, target) { }

    protected override int GetDamage()
    {
        return 1;
    }
}
