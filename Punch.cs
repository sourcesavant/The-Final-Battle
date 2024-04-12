namespace TheFinalBattle;

public class Punch : Attack
{
    public override string AttackName { get;  } = "PUNCH";
    
    public Punch(Character source, Character target) : base(source, target) { }
}
