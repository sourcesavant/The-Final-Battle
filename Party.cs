namespace TheFinalBattle;

public class Party
{
    public List<Character> Characters { get; } = new List<Character>();

    public List<Item> Items { get; } = new List<Item>();

    public void AddCharacter(Character character) => Characters.Add(character);

    public void AddItem(Item item) => Items.Add(item);
}
