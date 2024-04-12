namespace TheFinalBattle;

public class BoneCrunch : Attack
{  
    public BoneCrunch(Character source, Character target) : base(source, target) { AttackName = "BONE CRUNCH"; }

    protected override int GetDamage()
    {
        Random random = new Random();
        return random.Next(2);
    }
}
