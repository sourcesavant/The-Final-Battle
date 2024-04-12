namespace TheFinalBattle;

public class Battle
{
    private Party _heroesParty;
    private Party _monstersParty;
    private ComputerPlayer _heroesPlayer;
    private ComputerPlayer _monstersPlayer;
    private Renderer _renderer;

    public Battle(Party heroes, Party monsters, ComputerPlayer heroesPlayer, ComputerPlayer monstersPlayer, Renderer renderer)
    {
        _heroesParty = heroes;
        _monstersParty = monsters;
        _heroesPlayer = heroesPlayer;
        _monstersPlayer = monstersPlayer;
        _renderer = renderer;
    }

    public void DoRound()
    {
        foreach (Character character in _heroesParty.Characters)
        {
            _renderer.PrintLine($"It is {character.Name}'s turn...");
            _renderer.PrintLine($"{character.Name} did {character.DoAction(this, _heroesPlayer.PickAction())}");
            _renderer.PrintLine("");
        }

        foreach (Character character in _monstersParty.Characters)
        {
            _renderer.PrintLine($"It is {character.Name}'s turn...");
            _renderer.PrintLine($"{character.Name} did {character.DoAction(this, _monstersPlayer.PickAction())}");
            _renderer.PrintLine("");
        }
    }
}
