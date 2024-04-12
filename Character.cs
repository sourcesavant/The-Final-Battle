namespace TheFinalBattle;

public abstract class Character
{
    public abstract string Name { get; }

    public string DoAction(Battle battle, IAction action)
    {
        return action.Execute(battle);
    }
}
