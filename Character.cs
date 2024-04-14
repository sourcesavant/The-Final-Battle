namespace TheFinalBattle;

public abstract class Character
{
    public abstract string Name { get; }
    public abstract int MaxHP { get; }

    private int _HP;
    public int HP
    { 
        get => _HP;
        set => _HP = value < 0
                   ? 0
                   : value;
    }

    public Character()
    {
        _HP = MaxHP;
    }

    public string DoAction(Battle battle, IAction action)
    {
        return action.Execute(battle);
    }

    public override string ToString() => $"{Name} ( {HP}/{MaxHP} )";
}
