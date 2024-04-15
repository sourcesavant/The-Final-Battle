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
        heroes.AddCharacter(new TrueProgrammer(trueProgrammerName));
        heroes.AddItem(new HealthPotion());
        heroes.AddItem(new HealthPotion());
        heroes.AddItem(new HealthPotion());
        monsters.AddCharacter(new SKELETON());
        monsters.AddItem(new HealthPotion());
        _battle = new(heroes, monsters, _renderer);

        DisplayGameModeMenu();
        int menuChoice = _userInput.GetMenuChoice(3);
        (Player heroesPlayer, Player monstersPlayer) = menuChoice switch
        {
            1 => ((Player)new HumanPlayer(_battle, _renderer, _userInput), (Player)new ComputerPlayer(_battle, _renderer)),
            2 => ((Player)new ComputerPlayer(_battle, _renderer), (Player)new ComputerPlayer(_battle, _renderer)),
            3 => ((Player)new HumanPlayer(_battle, _renderer, _userInput), (Player)new HumanPlayer(_battle, _renderer, _userInput)),
            _ => throw new InvalidOperationException()
        };
        _battle.SetHeroesPlayer(heroesPlayer);
        _battle.SetMonstersPlayer(monstersPlayer);
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
            _renderer.PrintLine("The heroes won the second round.");
        else
            _renderer.PrintLine("The heroes lost. The Uncoded One's forces have prevailed.");

        // Round 3
        SetupThirdRound();
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
    private void SetupSecondRound()
    {
        Party monsters = new();
        monsters.AddCharacter(new SKELETON());
        monsters.AddCharacter(new SKELETON());
        monsters.AddItem(new HealthPotion());
        _battle.MonstersParty = monsters;
    }

    private void SetupThirdRound()
    {
        Party monsters = new();
        monsters.AddCharacter(new TheUncodedOne());
        monsters.AddItem(new HealthPotion());
        _battle.MonstersParty = monsters;
    }

    private void DisplayGameModeMenu()
    {
        _renderer.PrintLine("Choose your game mode");
        _renderer.PrintLine($"1 - Human vs. Computer");
        _renderer.PrintLine($"2 - Computer vs. Computer");
        _renderer.PrintLine($"3 - Human vs. Human");
    }
}
