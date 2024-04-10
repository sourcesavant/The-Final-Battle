namespace TheFinalBattle;

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();

    public void add(Character character) => Characters.Add(character);
}
