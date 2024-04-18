namespace TheFinalBattle;

/// <summary>
/// Stone Amarok monster. Has 4 HP and Stone Armor DefensiveModifier.
/// </summary>
public class StoneAmarok : Monster
{
    public override string Name { get; } = "Stone Amarok";
    public override int MaxHP { get; } = 4;

    public StoneAmarok()
    {
        DefensiveAttackModifier = new StoneArmor();
    }
}
