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
        IAction action = (menuChoice, character) switch
        {
            (1, SKELETON)       => new BoneCrunch(character, target),
            (1, TheUncodedOne)  => new Unraveling(character, target),
            (1, TrueProgrammer) => new Punch(character, target),
            (2, _)              => new SkipTurn(character)
        };
              
        return action.Execute(_battle);
    }

    private void DisplayMenu(Character character)
    {
        string attackName = character switch
        {
            SKELETON => BoneCrunch.AttackName,
            TheUncodedOne => Unraveling.AttackName,
            TrueProgrammer => Punch.AttackName,
        };
        _renderer.PrintLine($"1 - Standard Attack ({attackName})");
        _renderer.PrintLine($"2 - Do Nothing");
    }
}
