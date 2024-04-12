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

    public void DoRound()
    {
        foreach (Character character in _heroes.Characters)
        {
            _renderer.Print($"It is {character.Name}'s turn...");
            _renderer.Print($"{character.Name} did {character.PickAction(this)}");
            _renderer.Print("");
        }

        foreach (Character character in _monsters.Characters)
        {
            _renderer.Print($"It is {character.Name}'s turn...");
            _renderer.Print($"{character.Name} did {character.PickAction(this)}");
            _renderer.Print("");
        }
    }
}
