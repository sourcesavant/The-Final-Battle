namespace TheFinalBattle;

public abstract class Character
{
    public abstract string Name { get; }

    public abstract string PickAction(Battle battle);

    protected string DoAction(Battle battle, IAction action)
    {
        return action.Execute(battle);
    }
}
