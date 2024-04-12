namespace TheFinalBattle;

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();

    public void Add(Character character) => Characters.Add(character);
}
