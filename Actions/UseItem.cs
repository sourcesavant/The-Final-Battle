﻿namespace TheFinalBattle;

/// <summary>
/// Use item action.
/// </summary>
public class UseItem : IAction
{
    private readonly Item _item;
    private readonly Character _user;

    public UseItem(Item item, Character user)
    {
        _item = item;
        _user = user;
    }

    public string Execute(Battle battle)
    {
        if (_item is HealthPotion)
        {
            if (!battle.GetPartyForCharacter(_user).Items.Contains(_item))
                throw new InvalidOperationException();
            _user.HP += 10;
            battle.GetPartyForCharacter(_user).Items.Remove(_item);
        }
        return $"{_user.Name} used a Health Potion";
    }

}
