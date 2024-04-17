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
        _battle = new(_renderer);
        
        SetupHeroParty();
        SetupGameMode();
    }

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

    public void Run()
    {
        // Round 1
        SetupFirstRound();
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

    private bool HasHeroWon()
    {
        if (_battle.HeroesParty == null || _battle.MonstersParty == null)
            throw new InvalidOperationException();
        return !_battle.HeroesParty.IsDead() && _battle.MonstersParty.IsDead();
    }
    

    private bool HasHeroLost()
    {
        if (_battle.HeroesParty == null || _battle.MonstersParty == null)
            throw new InvalidOperationException();
        return _battle.HeroesParty.IsDead() && !_battle.MonstersParty.IsDead();
    }

    private void GameLoop()
    {
        while (!HasHeroWon() && !HasHeroLost())
        {
            _battle.DoRound();
            Thread.Sleep(500);
        }
    }

    private void SetupHeroParty()
    {
        Party heroes = new();
        string trueProgrammerName = _userInput.GetTrueProgammerName();
        Character trueProgrammer = new TrueProgrammer(trueProgrammerName);
        trueProgrammer.Gear = new Sword();
        heroes.AddCharacter(trueProgrammer);
        heroes.AddItem(new HealthPotion());
        heroes.AddItem(new HealthPotion());
        heroes.AddItem(new HealthPotion());
        _battle.HeroesParty = heroes;
    }

    private void SetupFirstRound()
    {
        Party monsters = new();
        SKELETON skeleton = new SKELETON();
        skeleton.Gear = new Dagger();
        monsters.AddCharacter(skeleton);
        monsters.AddItem(new HealthPotion());
        _battle.MonstersParty = monsters;
    }
    
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
