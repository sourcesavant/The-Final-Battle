namespace TheFinalBattle;

public abstract class Character
{
    public abstract string Name { get; }

    public abstract string pickAction(Battle battle);

    protected string doAction(Battle battle, IAction action)
    {
        return action.execute(battle);
    }
}
