namespace TheFinalBattle;

public class Battle
{
    private Party _heroes;
    private Party _monsters;
    private Renderer _renderer;

    public Battle(Party heroes, Party monsters, Renderer renderer)
    {
        _heroes = heroes;
        _monsters = monsters;
        _renderer = renderer;
    }

    public void doRound()
    {
        foreach (Character character in _heroes.Characters)
        {
            _renderer.print($"It is {character.Name}'s turn...");
            _renderer.print($"{character.Name} did {character.pickAction(this)}");
            _renderer.print("");
        }

        foreach (Character character in _monsters.Characters)
        {
            _renderer.print($"It is {character.Name}'s turn...");
            _renderer.print($"{character.Name} did {character.pickAction(this)}");
            _renderer.print("");
        }
    }
}
