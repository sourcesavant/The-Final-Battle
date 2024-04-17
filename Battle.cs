namespace TheFinalBattle;

public class Battle
{
    public Party? HeroesParty { get; set; }
    public Party? MonstersParty { get; set; }
    private Player? _heroesPlayer;
    private Player? _monstersPlayer;
    private Renderer _renderer;

    public Battle(Renderer renderer)
    {
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

    public Party GetPartyForCharacter(Character character) => character is Hero ? HeroesParty : MonstersParty;
    
    public Party GetEnemyPartyForCharacter(Character character) => character is Hero ? MonstersParty : HeroesParty;

    public void DoRound()
    {
        if (_heroesPlayer == null || _monstersPlayer == null)
            throw new InvalidOperationException();
        ExecuteActions(_heroesPlayer);
        ExecuteActions(_monstersPlayer);
    }

    private void ExecuteActions(Player player)
    {
        Party party = GetPartyForPlayer(player);
        foreach (Character character in party.Characters)
        {
            if (!GetEnemyPartyForPlayer(player).IsDead())
            {
                _renderer.PrintStatus(HeroesParty, MonstersParty);
                _renderer.PrintLine($"It is {character.Name}'s turn...");
                _renderer.PrintLine(player.PickAction(character));
                _renderer.PrintLine("");
            }
        }
    }

    private Party GetPartyForPlayer(Player player) 
    {
        if (player == _heroesPlayer)
            return HeroesParty;
        if (player == _monstersPlayer)
            return MonstersParty;
        throw new ArgumentOutOfRangeException();
    }

    private Party GetEnemyPartyForPlayer(Player player)
    {
        if (player == _heroesPlayer)
            return MonstersParty;
        if (player == _monstersPlayer)
            return HeroesParty;
        throw new ArgumentOutOfRangeException();
    }
}
