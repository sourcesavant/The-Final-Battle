﻿namespace TheFinalBattle;

public abstract class Character
{
    public abstract string Name { get; }
    public abstract int MaxHP { get; }

    public Gear? Gear { get; set; } = null;

    public DefensiveAttackModifier? DefensiveAttackModifier { get; init; }

    private int _HP;
    public int HP
    { 
        get => _HP;
        set
        {
            if (value < 0)
                _HP = 0;
            else if (value > MaxHP)
                _HP = MaxHP;
            else
                _HP = value;
        }
    }

    public Character()
    {
        _HP = MaxHP;
    }

    public bool IsDead() => _HP == 0;

    public bool HasGear() => Gear != null;

    public string DoAction(Battle battle, IAction action)
    {
        return action.Execute(battle);
    }

    public override string ToString() => $"{Name} ( {HP}/{MaxHP} )";
}
