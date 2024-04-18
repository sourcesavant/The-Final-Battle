namespace TheFinalBattle;

public class ComputerPlayer : Player
{
    private readonly Random _random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="ComputerPlayer"/> class.
    /// </summary>
    /// <param name="battle">The battle instance.</param>
    /// <param name="renderer">The renderer instance.</param>
    public ComputerPlayer(Battle battle, Renderer renderer) : base(battle, renderer) { }

    /// <summary>
    /// Picks the action for the computer player.
    /// Computer player prefers to use health potions if health is low, equip gear if possible, and attack with weapon if available. 
    /// </summary>
    /// <param name="character">The character to pick the action for.</param>
    /// <returns>Description of the result of the executed action.</returns>
    public override string PickAction(Character character)
    {
        if (WantsToUseHealthPotion(character))
            return new UseItem(new HealthPotion(), character).Execute(_battle);

        if (WantsToEquipGear(character))
            return new EquipGear(character, _battle.GetPartyForCharacter(character).Gear.First()).Execute(_battle);

        if (character.Gear != null)
            return GetWeaponAttackAction(character, _battle.GetEnemyPartyForCharacter(character).Characters.First()).Execute(_battle);

        return GetStandardAttackAction(character, _battle.GetEnemyPartyForCharacter(character).Characters.First()).Execute(_battle);
    }

    /// <summary>
    /// Determines whether the computer player wants to use a health potion.
    /// </summary>
    /// <param name="character">The character to check.</param>
    /// <returns><c>true</c> if the computer player wants to use a health potion; otherwise, <c>false</c>.</returns>
    private bool WantsToUseHealthPotion(Character character)
    {
        Party party = _battle.GetPartyForCharacter(character);
        if (party.Items.Any(item => item.GetType() == typeof(HealthPotion)) && character.HP < (float)character.MaxHP / 2)
            return (_random.Next(4) == 0);
        return false;
    }

    /// <summary>
    /// Determines whether the computer player wants to equip gear.
    /// </summary>
    /// <param name="character">The character to check.</param>
    /// <returns><c>true</c> if the computer player wants to equip gear; otherwise, <c>false</c>.</returns>
    private bool WantsToEquipGear(Character character)
    {
        if (character.Gear == null && _battle.GetPartyForCharacter(character).Gear.Count > 0)
            return (_random.Next(2) == 0);
        return false;
    }
}
