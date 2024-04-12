namespace TheFinalBattle;

public class Battle
{
    private Party _heroesParty;
    private Party _monstersParty;
    private ComputerPlayer _heroesPlayer;
    private ComputerPlayer _monstersPlayer;
    private Renderer _renderer;

    public Battle(Party heroes, Party monsters, Renderer renderer)
    {
        _heroesParty = heroes;
        _monstersParty = monsters;
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

    public Party GetPartyFor(Character character) => character is Hero ? _heroesParty : _monstersParty;
    
    public Party GetEnemyPartyFor(Character character) => character is Hero ? _monstersParty : _heroesParty;

    public void DoRound()
    {
        foreach (Character character in _heroesParty.Characters)
        {
            _renderer.PrintLine($"It is {character.Name}'s turn...");
            _renderer.PrintLine(_heroesPlayer.PickAction(character));
            _renderer.PrintLine("");
        }

        foreach (Character character in _monstersParty.Characters)
        {
            _renderer.PrintLine($"It is {character.Name}'s turn...");
            _renderer.PrintLine(_monstersPlayer.PickAction(character));
            _renderer.PrintLine("");
        }
    }
}
