namespace TheFinalBattle;

public class Battle
{
    public Party HeroesParty { get; private set; }
    public Party MonstersParty { get; private set; }
    private ComputerPlayer _heroesPlayer;
    private ComputerPlayer _monstersPlayer;
    private Renderer _renderer;

    public Battle(Party heroes, Party monsters, Renderer renderer)
    {
        HeroesParty = heroes;
        MonstersParty = monsters;
        _renderer = renderer;
        _heroesPlayer = new ComputerPlayer(this);
        _monstersPlayer = new ComputerPlayer(this);
    }

    public void SetHeroesPlayer(ComputerPlayer heroesPlayer) 
    {
        _heroesPlayer = heroesPlayer;
    }

    public void SetMonstersPlayer(ComputerPlayer monstersPlayer)
    {
        _monstersPlayer = monstersPlayer;
    }

    public Party GetPartyFor(Character character) => character is Hero ? HeroesParty : MonstersParty;
    
    public Party GetEnemyPartyFor(Character character) => character is Hero ? MonstersParty : HeroesParty;

    public void DoRound()
    {
        foreach (Character character in HeroesParty.Characters)
        {
            if (GetEnemyPartyFor(character).Characters.Count() == 0)
                break;
            _renderer.PrintLine($"It is {character.Name}'s turn...");
            _renderer.PrintLine(_heroesPlayer.PickAction(character));
            _renderer.PrintLine("");
        }

        foreach (Character character in MonstersParty.Characters)
        {
            if (GetEnemyPartyFor(character).Characters.Count() == 0)
                break;
            _renderer.PrintLine($"It is {character.Name}'s turn...");
            _renderer.PrintLine(_monstersPlayer.PickAction(character));
            _renderer.PrintLine("");
        }
    }
}
