namespace TheFinalBattle;

/// <summary>
/// Interface for actions that can be executed in battle.
/// </summary>
public interface IAction
{
    public string Execute(Battle battle);
}
    