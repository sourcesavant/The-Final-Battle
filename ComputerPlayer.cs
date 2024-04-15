namespace TheFinalBattle;

public class ComputerPlayer : Player
{
    private readonly Random _random = new Random();

    public ComputerPlayer(Battle battle, Renderer renderer) : base(battle, renderer) { }

    public override string PickAction(Character character)
    {
        if (WantsToUseHealthPotion(character))
            return new UseItem(new HealthPotion(), character).Execute(_battle);

        if (WantsToEquipGear(character))
            return new EquipGear(character, _battle.GetPartyFor(character).Gear.First()).Execute(_battle);

        if (character.Gear != null)
            return GetWeaponAttackAction(character, _battle.GetEnemyPartyFor(character).Characters.First()).Execute(_battle);

        return GetStandardAttackAction(character, _battle.GetEnemyPartyFor(character).Characters.First()).Execute(_battle);
    }

    private bool WantsToUseHealthPotion(Character character)
    {
        Party party = _battle.GetPartyFor(character);
        if (party.Items.Any(item => item.GetType() == typeof(HealthPotion)) && character.HP < (float)character.MaxHP / 2)
            return (_random.Next(4) == 0);
        return false;
    }

    private bool WantsToEquipGear(Character character)
    {
        if (character.Gear == null && _battle.GetPartyFor(character).Gear.Count > 0)
            return (_random.Next(2) == 0);
        return false;
    }
}
