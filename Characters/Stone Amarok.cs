namespace TheFinalBattle;

public class StoneAmarok : Monster
{
    public override string Name { get; } = "Stone Amarok";
    public override int MaxHP { get; } = 4;

    public StoneAmarok()
    {
        DefensiveAttackModifier = new StoneArmor();
    }
}
