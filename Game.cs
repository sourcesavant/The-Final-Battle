namespace TheFinalBattle;

public class Game
{
    private Battle _battle;
    private Renderer _renderer;
    private UserInput _userInput;

    public Game(Renderer renderer, UserInput userInput)
    {
        _renderer = renderer;
        _userInput = userInput;

        Party heroes = new();
        Party monsters = new();
        string trueProgrammerName = _userInput.GetTrueProgammerName();
        heroes.Add(new TrueProgrammer(trueProgrammerName));
        monsters.Add(new SKELETON());
        _battle = new(heroes, monsters, _renderer);
    }
    
    private void SetupSecondRound()
    {
        Party monsters = new();
        monsters.Add(new SKELETON());
        monsters.Add(new SKELETON());
        _battle.MonstersParty = monsters;
    }
   
    public void Run()
    {
        // Round 1
        GameLoop();
        if (HasHeroWon())
            _renderer.PrintLine("The heroes won the first round.");
        else
            _renderer.PrintLine("The heroes lost. The Uncoded One's forces have prevailed.");

        // Round 2
        SetupSecondRound();
        GameLoop();
        if (HasHeroWon())
            _renderer.PrintLine("The heroes won. The Uncoded One was defeated.");
        else
            _renderer.PrintLine("The heroes lost. The Uncoded One's forces have prevailed.");
    }

    private bool HasHeroWon() => _battle.HeroesParty.Characters.Count() > 0 && _battle.MonstersParty.Characters.Count() == 0;

    private bool HasHeroLost() => _battle.HeroesParty.Characters.Count() == 0 && _battle.MonstersParty.Characters.Count() > 0;

    private void GameLoop()
    {
        while (true)
        {
            _battle.DoRound();
            if (HasHeroWon() || HasHeroLost())
                break;
            Thread.Sleep(500);
        }
    }
}
