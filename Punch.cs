namespace TheFinalBattle;

public class Punch : Attack
{  
    public Punch(Character source, Character target) : base(source, target) { AttackName = "PUNCH"; }

    protected override int GetDamage()
    {
        return 1;
    }
}
