namespace TheFinalBattle;

public class Battle
{
    public Party HeroesParty { get; private set; }
    public Party MonstersParty { get; set; }
    private Player? _heroesPlayer;
    private Player? _monstersPlayer;
    private Renderer _renderer;

    public Battle(Party heroes, Party monsters, Renderer renderer)
    {
        HeroesParty = heroes;
        MonstersParty = monsters;
        _renderer = renderer;        
    }

    public void SetHeroesPlayer(Player heroesPlayer) 
    {
        _heroesPlayer = heroesPlayer;
    }

    public void SetMonstersPlayer(Player monstersPlayer)
    {
        _monstersPlayer = monstersPlayer;
    }

    public Party GetPartyFor(Character character) => character is Hero ? HeroesParty : MonstersParty;
    
    public Party GetEnemyPartyFor(Character character) => character is Hero ? MonstersParty : HeroesParty;

    public void DoRound()
    {
        if (_heroesPlayer == null || _monstersPlayer == null)
            throw new InvalidOperationException();
        DoRoundOfPlayer(_heroesPlayer, HeroesParty);
        DoRoundOfPlayer(_monstersPlayer, MonstersParty);
    }

    private void DoRoundOfPlayer(Player player, Party party)
    {
        foreach (Character character in party.Characters)
        {
            if (GetEnemyPartyFor(character).Characters.Count() == 0)
                break;
            _renderer.PrintStatus(HeroesParty, MonstersParty);
            _renderer.PrintLine($"It is {character.Name}'s turn...");
            _renderer.PrintLine(player.PickAction(character));
            _renderer.PrintLine("");
        }
    }
}
