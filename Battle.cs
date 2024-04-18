namespace TheFinalBattle;

/// <summary>
/// Represents a battle between two parties in the game.
/// </summary>
public class Battle
{
    /// <summary>
    /// Gets or sets the party of heroes.
    /// </summary>
    public Party? HeroesParty { get; set; }

    /// <summary>
    /// Gets or sets the party of monsters.
    /// </summary>
    public Party? MonstersParty { get; set; }

    /// <summary>
    /// Player controlling the heroes.
    /// </summary>
    private Player? _heroesPlayer;
    /// <summary>
    /// Player controlling the monsters.
    /// </summary>
    private Player? _monstersPlayer;
    /// <summary>
    /// Renderer used to display the battle.
    /// </summary>
    private Renderer _renderer;

    /// <summary>
    /// Initializes a new instance of the Battle class.
    /// </summary>
    /// <param name="renderer">The renderer used to display the battle.</param>
    public Battle(Renderer renderer)
    {
        _renderer = renderer;
    }

    /// <summary>
    /// Sets the player controlling the heroes.
    /// </summary>
    /// <param name="heroesPlayer">The player controlling the heroes.</param>
    public void SetHeroesPlayer(Player heroesPlayer)
    {
        _heroesPlayer = heroesPlayer;
    }

    /// <summary>
    /// Sets the player controlling the monsters.
    /// </summary>
    /// <param name="monstersPlayer">The player controlling the monsters.</param>
    public void SetMonstersPlayer(Player monstersPlayer)
    {
        _monstersPlayer = monstersPlayer;
    }

    /// <summary>
    /// Gets the party that a character belongs to.
    /// </summary>
    /// <param name="character">The character whose party to get.</param>
    /// <returns>The party that the character belongs to.</returns>
    public Party GetPartyForCharacter(Character character) => character is Hero ? HeroesParty : MonstersParty;

    /// <summary>
    /// Gets the enemy party of a character.
    /// </summary>
    /// <param name="character">The character whose enemy party to get.</param>
    /// <returns>The enemy party of the character.</returns>
    public Party GetEnemyPartyForCharacter(Character character) => character is Hero ? MonstersParty : HeroesParty;

    /// <summary>
    /// Executes a round of the battle.
    /// </summary>
    /// <exception cref="System.InvalidOperationException">Thrown when either the heroes player or the monsters player is null.</exception>
    public void DoRound()
    {
        if (_heroesPlayer == null || _monstersPlayer == null)
            throw new InvalidOperationException();
        ExecuteActions(_heroesPlayer);
        ExecuteActions(_monstersPlayer);
    }

    /// <summary>
    /// Executes the actions of a player's party.
    /// </summary>
    /// <param name="player"></param>
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

    /// <summary>
    /// Gets the party for a player.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private Party GetPartyForPlayer(Player player)
    {
        if (player == _heroesPlayer)
            return HeroesParty;
        if (player == _monstersPlayer)
            return MonstersParty;
        throw new ArgumentOutOfRangeException();
    }

    /// <summary>
    /// Gets the enemy party for a player.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private Party GetEnemyPartyForPlayer(Player player)
    {
        if (player == _heroesPlayer)
            return MonstersParty;
        if (player == _monstersPlayer)
            return HeroesParty;
        throw new ArgumentOutOfRangeException();
    }
}

