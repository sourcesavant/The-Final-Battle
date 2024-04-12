namespace TheFinalBattle;

public class BoneCrunch : Attack
{
    public override string AttackName { get; } = "BONE CRUNCH";
    
    public BoneCrunch(Character source, Character target) : base(source, target) { }
}
