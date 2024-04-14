namespace TheFinalBattle;

public class HumanPlayer : Player
{
    private readonly UserInput _userInput;
    public HumanPlayer(Battle battle, Renderer renderer, UserInput userInput) : base(battle, renderer)
    {
        _userInput = userInput;
    }

    public override string PickAction(Character character)
    {
        Party enemy = _battle.GetEnemyPartyFor(character);
        Character target = enemy.Characters.First();

        DisplayMenu(character);
        int menuChoice = _userInput.GetMenuChoice(2);
        IAction action = (menuChoice) switch
        {
            1  => GetAttackAction(character, target),
            2  => new SkipTurn(character),
            _  => throw new NotImplementedException()
        };
              
        return action.Execute(_battle);
    }

    private void DisplayMenu(Character character)
    {
        _renderer.PrintLine($"1 - Standard Attack ({GetAttackName(character)})");
        _renderer.PrintLine($"2 - Do Nothing");
    }
}
