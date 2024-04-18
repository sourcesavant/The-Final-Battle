namespace TheFinalBattle;

/// <summary>
/// Represents a game that consists of battles between heroes and monsters.
/// </summary>
public class Game
{
    private Battle _battle;
    private Renderer _renderer;
    private UserInput _userInput;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    /// <param name="renderer">The renderer used to display game information.</param>
    /// <param name="userInput">The user input handler.</param>
    public Game(Renderer renderer, UserInput userInput)
    {
        _renderer = renderer;
        _userInput = userInput;
        _battle = new(_renderer);

        SetupHeroParty();
        SetupGameMode();
    }

    /// <summary>
    /// Sets up the game mode based on user input.
    /// </summary>
    private void SetupGameMode()
    {
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

    /// <summary>
    /// Runs the game, including battles against monsters and the final battle against the Uncoded One.
    /// </summary>
    public void Run()
    {
        RunBattlesAgainstMonsters();
        RunBattleAgainstUncodedOne();
    }

    /// <summary>
    /// Runs the battle against the Uncoded One.
    /// </summary>
    private void RunBattleAgainstUncodedOne()
    {
        SetupFinalRound();
        GameLoop();
        if (HasHeroWon())
            _renderer.PrintLine("The heroes won. The Uncoded One was defeated.");
        else
            _renderer.PrintLine("The heroes lost. The Uncoded One's forces have prevailed.");
    }

    /// <summary>
    /// Runs the battles against monsters in three rounds.
    /// </summary>
    private void RunBattlesAgainstMonsters()
    {
        for (int i = 1; i <= 3; i++)
        {
            SetupRound(i);
            GameLoop();
            if (HasHeroWon())
                _renderer.PrintLine("The heroes won this round.");
            else
                _renderer.PrintLine("The heroes lost. The Uncoded One's forces have prevailed.");
        }
    }

    /// <summary>
    /// Checks if the heroes have won the battle.
    /// </summary>
    /// <returns><c>true</c> if the heroes have won; otherwise, <c>false</c>.</returns>
    private bool HasHeroWon()
    {
        if (_battle.HeroesParty == null || _battle.MonstersParty == null)
            throw new InvalidOperationException();
        return !_battle.HeroesParty.IsDead() && _battle.MonstersParty.IsDead();
    }


    /// <summary>
    /// Checks if the heroes have lost the battle.
    /// </summary>
    /// <returns><c>true</c> if the heroes have lost; otherwise, <c>false</c>.</returns>
    private bool HasHeroLost()
    {
        if (_battle.HeroesParty == null || _battle.MonstersParty == null)
            throw new InvalidOperationException();
        return _battle.HeroesParty.IsDead() && !_battle.MonstersParty.IsDead();
    }

    /// <summary>
    /// Runs the game loop until the heroes win or lose.
    /// </summary>
    private void GameLoop()
    {
        while (!HasHeroWon() && !HasHeroLost())
        {
            _battle.DoRound();
            Thread.Sleep(500);
        }
    }

    /// <summary>
    /// Sets up the hero party with initial characters and items.
    /// </summary>
    private void SetupHeroParty()
    {
        Party heroes = new();

        string trueProgrammerName = _userInput.GetTrueProgammerName();
        Character trueProgrammer = new TrueProgrammer(trueProgrammerName);
        trueProgrammer.Gear = new Sword();
        heroes.AddCharacter(trueProgrammer);

        Character vinFletcher = new VinFletcher();
        vinFletcher.Gear = new VinsBow();
        heroes.AddCharacter(vinFletcher);

        heroes.AddItem(new HealthPotion());
        heroes.AddItem(new HealthPotion());
        heroes.AddItem(new HealthPotion());
        _battle.HeroesParty = heroes;
    }

    /// <summary>
    /// Sets up the round based on the round number.
    /// </summary>
    /// <param name="round">The round number.</param>
    private void SetupRound(int round)
    {
        switch (round)
        {
            case 1:
                SetupFirstRound();
                break;
            case 2:
                SetupSecondRound();
                break;
            case 3:
                SetupThirdRound();
                break;
            case 4:
                SetupFinalRound();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Sets up the first round with monsters and items.
    /// </summary>
    private void SetupFirstRound()
    {
        Party monsters = new();
        SKELETON skeleton = new SKELETON();
        skeleton.Gear = new Dagger();
        monsters.AddCharacter(skeleton);
        monsters.AddItem(new HealthPotion());
        _battle.MonstersParty = monsters;
    }

    /// <summary>
    /// Sets up the second round with monsters and items.
    /// </summary>
    private void SetupSecondRound()
    {
        Party monsters = new();
        monsters.AddCharacter(new SKELETON());
        monsters.AddCharacter(new SKELETON());
        monsters.AddItem(new HealthPotion());
        monsters.AddGear(new Dagger());
        monsters.AddGear(new Dagger());
        _battle.MonstersParty = monsters;
    }

    /// <summary>
    /// Sets up the third round with monsters.
    /// </summary>
    private void SetupThirdRound()
    {
        Party monsters = new();
        monsters.AddCharacter(new StoneAmarok());
        monsters.AddCharacter(new StoneAmarok());
        _battle.MonstersParty = monsters;
    }

    /// <summary>
    /// Sets up the final round with the Uncoded One and an item.
    /// </summary>
    private void SetupFinalRound()
    {
        Party monsters = new();
        monsters.AddCharacter(new TheUncodedOne());
        monsters.AddItem(new HealthPotion());
        _battle.MonstersParty = monsters;
    }

    /// <summary>
    /// Displays the game mode menu to the user.
    /// </summary>
    private void DisplayGameModeMenu()
    {
        _renderer.PrintLine("Choose your game mode");
        _renderer.PrintLine($"1 - Human vs. Computer");
        _renderer.PrintLine($"2 - Computer vs. Computer");
        _renderer.PrintLine($"3 - Human vs. Human");
    }
}
