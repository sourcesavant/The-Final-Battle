namespace TheFinalBattle;

/// <summary>
/// Equip gear action.
/// </summary>
public class EquipGear : IAction
{
    private readonly Character _character;
    private readonly Gear _gear;

    public EquipGear(Character character, Gear gear)
    {
        _character = character;
        _gear = gear;
    }

    public string Execute(Battle battle)
    {
        if (_character.Gear != null)
        {
            battle.GetPartyForCharacter(_character).Gear.Add(_character.Gear);
        }
        _character.Gear = _gear;
        battle.GetPartyForCharacter(_character).Gear.Remove(_gear);
        return $"{_character.Name} equipped {_gear.Name}.";
    }
}
