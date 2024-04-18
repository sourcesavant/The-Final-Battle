namespace TheFinalBattle;

/// <summary>
/// Skip turn action.
/// </summary>
public class SkipTurn : IAction
{
    private readonly Character _character;

    public SkipTurn(Character character)
    {
        _character = character;
    }

    public string Execute(Battle battle)
    {
        return $"{_character.Name} did NOTHING.";
    }
}
