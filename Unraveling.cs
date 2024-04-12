namespace TheFinalBattle;

public class Unraveling : Attack
{  
    public Unraveling(Character source, Character target) : base(source, target) { AttackName = "UNRAVELING ATTACK"; }

    protected override int GetDamage()
    {
        Random random = new Random();
        return random.Next(3);
    }
}
